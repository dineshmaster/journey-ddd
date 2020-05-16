namespace Journey.Domain.Model.Customer
{
    public enum CustomerSignUpStatus
    {
        Registered,
        PhoneNumberVarified,
        EmailVerified,
        Failed,
        AlreadyExists
    }
}