using System;
using DDDCinema.Common;

namespace DDDCinema.Promotions.Commands
{
	public class SetValidityDatesCommand : ICommand
	{
		public Guid PromotionId { get; set; }
		public DateTime? EndDate { get; set; }
		public DateTime? StartDate { get; set; }
	}

	public class SetValidityDatesCommandHandler : ICommandHandler<SetValidityDatesCommand>
	{
		private readonly IPromotionRepository _promotionRepository;

		public SetValidityDatesCommandHandler(IPromotionRepository promotionRepository)
		{
			_promotionRepository = promotionRepository;
		}

		public void Handle(SetValidityDatesCommand command)
		{
			PromotionDraft draft = _promotionRepository.GetDraftById(command.PromotionId);
			draft.SetValidityRange(ValidityRange.LimitedValidityRange(command.StartDate.Value, command.EndDate.Value));
		}
	}
}
