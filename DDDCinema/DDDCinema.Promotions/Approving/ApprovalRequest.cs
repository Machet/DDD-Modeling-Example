using System;

namespace DDDCinema.Promotions.Approving
{
	public class ApprovalRequest
	{
		public Guid Id { get; private set; }
		public Editor Editor { get; private set; }
		public ApprovalStatus Status { get; private set; }
		public string Comment { get; private set; }

		protected ApprovalRequest() { }

		public ApprovalRequest(Editor e)
		{
			Editor = e;
			Status = ApprovalStatus.Pending;
		}

		public void Approve()
		{
			Status = ApprovalStatus.Accepted;
		}

		public void Reject(string comment)
		{
			Comment = comment;
			Status = ApprovalStatus.Rejected;
		}
	}
}