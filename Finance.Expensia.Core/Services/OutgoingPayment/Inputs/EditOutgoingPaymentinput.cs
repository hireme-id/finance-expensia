namespace Finance.Expensia.Core.Services.OutgoingPayment.Inputs
{
	public class EditOutgoingPaymentInput : BaseOutgoingPaymentInput
	{
        public Guid Id { get; set; }

		public List<EditOutgoingPaymentDetailInput> OutgoingPaymentDetails { get; set; } = [];

		public List<EditOutgoingPaymentDetailTaggingInput> OutgoingPaymentTaggings { get; set; } = [];
	}

    public class EditOutgoingPaymentDetailInput : BaseOutgoingPaymentDetailInput
	{
        public Guid? Id { get; set; }

        public List<EditOutgoingPaymentDetailAttachmentInput> OutgoingPaymentDetailAttachments { get; set; } = [];
    }

    public class EditOutgoingPaymentDetailAttachmentInput : CreateOutgoingPaymentDetailAttachmentInput
	{
        public Guid? Id { get; set; }
    }

	public class EditOutgoingPaymentDetailTaggingInput : CreateOutgoingPaymentTaggingInput
	{
		public Guid? Id { get; set; }
	}
}
