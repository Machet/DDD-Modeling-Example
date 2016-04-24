using System;
using DDDCinema.Common;
using DDDCinema.Promotions;

namespace DDDCinema.Application.Promotions
{
	public class CreatePromotionCommand : ICommand
	{
		public Guid PromotionId { get; set; }
		public string PromotionName { get; set; }
	}

	public class CreatePromotionCommandHandler : ICommandHandler<CreatePromotionCommand>
	{
		private readonly IPromotionRepository _promotionRepository;
		private readonly IUserInRoleRepository _userInRoleRepository;
		private readonly ICurrentUserProvider _currentUserProvider;

		public CreatePromotionCommandHandler(
			IPromotionRepository promotionRepository,
			IUserInRoleRepository userInRoleRepository,
			ICurrentUserProvider currentUserProvider)
		{
			_promotionRepository = promotionRepository;
			_userInRoleRepository = userInRoleRepository;
			_currentUserProvider = currentUserProvider;
		}

		public void Handle(CreatePromotionCommand command)
		{
			Editor owner = _userInRoleRepository.GetEditor(_currentUserProvider.GetUserId().Value);
			PromotionDraft draft = new PromotionDraft(command.PromotionId, command.PromotionName, owner);
			_promotionRepository.Store(draft);
		}
	}
}
