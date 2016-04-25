using System;
using DDDCinema.Common;
using DDDCinema.Promotions;

namespace DDDCinema.Application.Promotions
{
	public class MarkPromotionAsReadyCommand : ICommand
	{
		public Guid PromotionId { get; set; }
	}

	public class MarkAsReadyCommandHandler : ICommandHandler<MarkPromotionAsReadyCommand>
	{
		private readonly IPromotionRepository _promotionRepository;

		public MarkAsReadyCommandHandler(IPromotionRepository promotionRepository)
		{
			_promotionRepository = promotionRepository;
		}

		public void Handle(MarkPromotionAsReadyCommand command)
		{
			PromotionDraft draft = _promotionRepository.GetDraftById(command.PromotionId);
			draft.MarkAsReady();
		}
	}
}
