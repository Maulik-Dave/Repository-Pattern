namespace Project_DotNetCore.Base.Modules.Core.Content
{
    public static class Messages
    {
        public const string AdminTryOwnAccountDelete = "You can't delete your own account.";
        public const string AdminTryOwnAccountInactive = "You can't inactive your own account.";
        public const string BothPasswordMatch = "'Password' should match to 'Confirm Password'.";
        public const string InvalidForgotPasswordToken = "Invalid forgot password token or token already expired.";
        public const string InvalidLogin = "You did not sign in correctly or your account is temporarily disabled.";
        public const string InvalidSiteSelected = "Invalid site selected.";
        public const string LanguageRecordDelete = "Language record has been deleted.";
        public const string PasswordUpdated = "Your password has been successfully updated.";
        public const string ProfileUpdated = "Your profile has been successfully updated.";
        public const string RecordActivate = "Record has been successfully activated.";
        public const string RecordDelete = "Total {0} record(s) has been deleted.";
        public const string RecordInactivate = "Record has been successfully deactivated.";
        public const string RecordNotFound = "Record not found.";
        public const string RecordSaved = "Record has been successfully saved.";
        public const string RecordNotSaved = "Record not saved successfully..";
        public const string SelectAtLeastOneItemFromList = "Select at least one item from list.";
        public const string SuccessResetPassword = "User's password has been reset";
        public const string UniqueRecord = "{PropertyName} already used with other records.";
        public const string RecordListed = "";
        public const string RecordUnlisted = "";
        public const string RecordClosed = "Total {0} record(s) has been closed.";
        public const string RecordSuspended = "Total {0} record(s) has been suspended.";
        public const string ProductReviewSaved = "Your review has been posted successfully.";
        public const string ProductQuestionSaved = "Your question has been sent to the product seller.";
        public const string SaveTicket = "Ticket created successfully. If there will any update, you will get the notification. Thank you!";
        public const string CloseTicket = "Ticket closed successfully.";
        public const string ReplyTicket = "Reply has been submitted.";
        public const string ReopenTicket = "Ticket reopened successfully.";
        public const string NotifyAdmin = "Ticket is notified to admin.";
        public const string DeleteDataFromDifferentUser = "Your user id does not match with any admin users for deleting the data";
        public const string RestoredRecord = "Item has been successfully restored";
        public const string CustomDelete = @"Deleted Items are stored in the <a href='https://dev.bpmds.com/settings/business-settings?activeTab=recycle-bin' className='Info-blue underline underline-offset-8'>Recycle Bin</a> for 30 days before permanetly deleted";
        public const string ExpenseErrorDelete = "Expense not deleted because they have been billed";
        public const string FlatFeesErrorDelete = "Flat Fees not deleted because they have been billed";
        public const string TimeEntryErrorDelete = "Time Entry not deleted because they have been billed";
        public const string CompanyStaffDelete = "Vendor Satff Removed";
        public const string RecordUpdate = "Record changes has been successfully saved";
        public const string ClientCreated = "Client has been Saved";
    }
}