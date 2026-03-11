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
        public static readonly string PasswordResetSubject = "Reset Your Password";
        public static readonly string PasswordResetMessage = "We received a request to reset your password. Use the OTP coe below to set a new password:";
        public static readonly string PasswordResetSecurityNotice = "If you didn’t request a password reset, you can safely ignore this email. Your account is safe.";
        public static readonly string AccountReactivationSubject = "Reactivate Your Account";
        public static readonly string AccountReactivationMessage = "We received a request to reactivate your account. Pleaseuse the OTP below to complete reactivation.";
        public static readonly string AccountReactivationSecurityNotice = "If you request a reactivation, you can safely ignore this email. Your account is safe.";
        public static readonly string WelcomeEmailSubject = "Welcome to {0}";
        public static readonly string InvalidRefreshToken = "Invalid refresh token";
        public static readonly string UserInactive = "User is inactive. Please reactivate your account to continue or contact support for assistance.";
        public static readonly string ExpiredToken = "Invalid or expired token";
        public static readonly string AccessDenied = "Access denied.";
        public static readonly string PasswordChanged = "Password changed successfully. Please login with the new password";
    }
}