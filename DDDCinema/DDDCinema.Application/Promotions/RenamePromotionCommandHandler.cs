using System;
using DDDCinema.Common;
using DDDCinema.Promotions;

namespace DDDCinema.Application.Promotions
{
	public class RenamePromotionCommand : ICommand
	{
		public Guid PromotionId { get; set; }
		public string PromotionName { get; set; }
	}

	public class RenamePromotionCommandHandler : ICommandHandler<RenamePromotionCommand>
	{
		private readonly IPromotionRepository _promotionRepository;

		public RenamePromotionCommandHandler(IPromotionRepository promotionRepository)
		{
			_promotionRepository = promotionRepository;
		}

		public void Handle(RenamePromotionCommand command)
		{
			PromotionDraft draft = _promotionRepository.GetDraftById(command.PromotionId);
			draft.Rename(command.PromotionName);
		}
	}
}
