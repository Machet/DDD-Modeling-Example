using System;
using System.Linq;
using System.Collections.Generic;
using DDDCinema.Common;

namespace DDDCinema.Promotions.Approving
{
    public class ApprovalProcess
    {
        public Guid Id { get; private set; }
        public Guid PromotionId { get; private set; }
        public List<ApprovalRequest> ApprovalRequests { get; private set; }
        public ApprovalStatus Status { get; private set; }

		protected ApprovalProcess() { }

        protected ApprovalProcess(Guid promotionId, HashSet<Editor> editors)
        {
            Id = Guid.NewGuid();
            PromotionId = promotionId;
            Status = ApprovalStatus.Pending;
            ApprovalRequests = editors.Select(e => new ApprovalRequest(e)).ToList();
        }

        public void ApproveFor(Editor editor)
        {
            var request = ApprovalRequests.FirstOrDefault(ar => ar.Editor.Equals(editor));
            if(request != null)
            {
                request.Approve();
                CheckCompletion();
            }
        }

        public void RejectFor(Editor editor, string reason)
        {
            var request = ApprovalRequests.FirstOrDefault(ar => ar.Editor.Equals(editor));
            if (request != null)
            {
                request.Reject(reason);
                CheckCompletion();
            }
        }

		public void Complete()
        {
            if (Status != ApprovalStatus.Pending)
            {
                return;
            }

            Status = ApprovalStatus.Accepted;
            DomainEventBus.Current.Raise(new PromotionApproved(PromotionId));
        }

        private void CheckCompletion()
        {
            if (Status != ApprovalStatus.Pending)
            {
                return;
            }

            if (ApprovalRequests.Any(r => r.Status == ApprovalStatus.Rejected))
            {
                Status = ApprovalStatus.Rejected;
                DomainEventBus.Current.Raise(new PromotionRejected(PromotionId));
                return;
            }

            if(ApprovalRequests.Count(r => r.Status == ApprovalStatus.Accepted) >= 2)
            {
                Status = ApprovalStatus.Accepted;
                DomainEventBus.Current.Raise(new PromotionApproved(PromotionId));
            }
        }

        public static ApprovalProcess StartFor(Guid promotionId, HashSet<Editor> editors)
        {
            return new ApprovalProcess(promotionId, editors);
        }
    }
}