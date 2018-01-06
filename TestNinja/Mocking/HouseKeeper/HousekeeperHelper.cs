using System;

namespace TestNinja.Mocking.HouseKeeper
{
    public class HousekeeperHelper
    {
        private readonly IHousekeeperService _housekeeperService;
        

        public HousekeeperHelper(IHousekeeperService housekeeperService)
        {
            _housekeeperService = housekeeperService;
        }
        
        public bool SendStatementEmails(DateTime statementDate)
        {
            var housekeepers = _housekeeperService.RetrieveHousekeepers();

            foreach (var housekeeper in housekeepers)
            {
                if (housekeeper.Email == null)
                    continue;

                var statementFilename = _housekeeperService.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate);

                if (string.IsNullOrWhiteSpace(statementFilename))
                    continue;

                var emailAddress = housekeeper.Email;
                var emailBody = housekeeper.StatementEmailBody;

                try
                {
                    _housekeeperService.EmailFile(emailAddress, emailBody, statementFilename,
                        string.Format("Sandpiper Statement {0:yyyy-MM} {1}", statementDate, housekeeper.FullName));
                }
                catch (Exception e)
                {
                    XtraMessageBox.Show(e.Message, string.Format("Email failure: {0}", emailAddress),
                        MessageBoxButtons.OK);
                }
            }

            return true;
        }
    }
}