using System;
using DDDCinema.Common;

namespace DDDCinema.Promotions
{
	public class PromotionDraft
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public ValidityRange ValidityRange { get; private set; }
		public Benefit Benefit { get; private set; }
		public ReceiveCondition ReceiveCondition { get; private set; }
		public DraftState State { get; private set; }
		public Editor Owner { get; private set; }
		public DateTime CreationDate { get; private set; }

		protected PromotionDraft() { }

		public PromotionDraft(Guid id, string name, Editor owner)
		{
			Require.NotEmpty(name, nameof(name));
			Require.NotNull(owner, nameof(owner));
			Id = id;
			Name = name;
			Owner = owner;
			ValidityRange = ValidityRange.NotSpecified();
			CreationDate = DomainTime.Current.Now;
		}

		public void Rename(string newName)
		{
			Require.NotEmpty(newName, nameof(newName));
			Name = newName;
		}

		public void SetValidityRange(ValidityRange range)
		{
			Require.NotNull(range, nameof(range));
			Require.IsNotIn(State, DraftState.Completed, DraftState.Accepted);
			ValidityRange = range;
		}

		public void SetBenefit(Benefit benefit)
		{
			Require.NotNull(benefit, nameof(benefit));
			Require.IsNotIn(State, DraftState.Completed, DraftState.Accepted);
			Benefit = benefit;
		}

		public void SetReceiveCondition(ReceiveCondition condition)
		{
			Require.NotNull(condition, nameof(condition));
			Require.IsNotIn(State, DraftState.Completed, DraftState.Accepted);
			ReceiveCondition = condition;
		}

		public void MarkAsReady()
		{
			Require.NotNull(ValidityRange, nameof(ValidityRange));
			Require.NotNull(Benefit, nameof(Benefit));
			Require.NotNull(ReceiveCondition, nameof(ReceiveCondition));
			Require.IsTrue(() => ValidityRange.IsDefined() && ValidityRange.StartsAfter(DomainTime.Current.Now), "validity range should be in future");
			Require.IsIn(State, DraftState.New, DraftState.FixesRequired);
			State = DraftState.Completed;
			DomainEventBus.Current.Raise(new PromotionDraftReady(Id, Owner.Id));
		}

		internal void MarkAsAccepted()
		{
			Require.IsIn(State, DraftState.Completed);
			State = DraftState.Accepted;
		}

		internal void MarkAsReworkNeeded()
		{
			Require.IsIn(State, DraftState.Completed);
			State = DraftState.FixesRequired;
		}

		public Promotion CreatePromotion()
		{
			Require.IsIn(State, DraftState.Accepted);
			return new Promotion(ValidityRange, ReceiveCondition, Benefit);
		}
	}
}
