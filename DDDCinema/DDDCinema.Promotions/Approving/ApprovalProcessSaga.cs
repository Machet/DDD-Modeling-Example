using DDDCinema.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDCinema.Promotions.Approving
{
    public class ApprovalProcessSaga :
        IDomainEventHandler<PromotionDraftReady>,
        IDomainEventHandler<PromotionApproved>,
        IDomainEventHandler<PromotionRejected>,
        ITimeoutHandler<ApprovalProcessTimeout>
    {
        private readonly IUserInRoleRepository _userInRoleRepository;
        private readonly IApprovalRepository _approvalRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly ISheduler _sheduler;

        public ApprovalProcessSaga(IUserInRoleRepository userInRoleRepository, IApprovalRepository approvalRepository, IPromotionRepository promotionRepository, ISheduler sheduler)
        {
            _userInRoleRepository = userInRoleRepository;
            _approvalRepository = approvalRepository;
            _promotionRepository = promotionRepository;
            _sheduler = sheduler;
        }

        public void Handle(PromotionDraftReady @event)
        {
            IEnumerable<Editor> editors = _userInRoleRepository.GetAllEditors()
                .Where(e => e.Id != @event.OwnerId);

            ApprovalProcess approvalProcess = ApprovalProcess.StartFor(@event.PromotionId, new HashSet<Editor>(editors));
            _approvalRepository.Store(approvalProcess);
            _sheduler.RequestTimeout(new ApprovalProcessTimeout(approvalProcess.Id), TimeSpan.FromDays(3));
        }

        public void Handle(PromotionApproved @event)
        {
            PromotionDraft draft = _promotionRepository.GetDraftById(@event.PromotionId);
            draft.MarkAsAccepted();
            _promotionRepository.Store(draft.CreatePromotion());
        }

        public void Handle(PromotionRejected @event)
        {
            PromotionDraft draft = _promotionRepository.GetDraftById(@event.PromotionId);
            draft.MarkAsReworkNeeded();
        }

        public void HandleTimeout(ApprovalProcessTimeout timeoutData)
        {
            ApprovalProcess process = _approvalRepository.GetProcess(timeoutData.ApprovalProcessId);
            process.Complete();
        }
    }
}
