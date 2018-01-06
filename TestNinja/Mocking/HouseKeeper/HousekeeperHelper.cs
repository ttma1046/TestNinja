using System;

namespace TestNinja.Mocking.HouseKeeper
{
    public class HousekeeperHelper
    {
        private readonly IHousekeeperService _housekeeperService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatementGenerator _statementGenerator;

        public HousekeeperHelper(IHousekeeperService housekeeperService, IUnitOfWork unitOfWork, IStatementGenerator statementGenerator)
        {
            _housekeeperService = housekeeperService;
            _unitOfWork = unitOfWork;
            _statementGenerator = statementGenerator;
        }
        
        public bool SendStatementEmails(DateTime statementDate)
        {
            var housekeepers = _unitOfWork.Query<Housekeeper>();

            foreach (var housekeeper in housekeepers)
            {
                if (housekeeper.Email == null)
                    continue;

                var statementFilename = _statementGenerator.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate);

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