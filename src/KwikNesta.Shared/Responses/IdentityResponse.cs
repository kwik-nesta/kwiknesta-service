namespace KwikNesta.Shared.Responses
{
    public static class IdentityResponse
    {
        public static readonly string UserExists = "A user already exists with this email, please login instead.";
        public static readonly string RegistrationFailed = "User registration failed. Please try again";
        public static readonly string AccountActivationSubject = "Email Confirmation";
        public static readonly string InvalidRegistrationRole = "Invalid role for registration.";
        public static readonly string AccountActivationMessage = "Welcome! Please use the following OTP to confirm your account:";
        public static readonly string AccountActivationSecurityNotice = "If you didn’t create this account, you can safely ignore this email.";
        public static readonly string InvalidRequest = "Invalid request. Please check your inputs and try again";
        public static readonly string UserNotFoundWithEmail = "No user found with the specified email address";
        public static readonly string InvalidOtp = "Invalid OTP. Please check and try again.";
        public static readonly string AccountVerificationSuccessful = "Account successfully verified. Please proceed to login";
        public static readonly string OtpExpired = "OTP has expired. Please request for a new one.";
        public static readonly string InvalidEmailOrPassword = "Email address and Password are required fields.";
        public static readonly string EmailNotConfirmedOrAccountInactive = "Account not activated. Please activate your account or contact support for assistance.";
        public static readonly string WrongPassword = "You entered an incorrect password.";
        public static readonly string NoAssignedRoles = "You have no assigned role. Please contact support for assistance.";
        public static readonly string UserNotFoundWithId = "No user found with the specified id";
        public static readonly string UserAlreadyVerified = "Account already verified. Please login";
        public static readonly string ActivationOtpSent = "OTP successfully resent. Please check your email.";
    }
}