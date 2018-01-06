using System.Linq;

namespace TestNinja.Mocking.HouseKeeper
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    
    public class HousekeeperService : IHousekeeperService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HousekeeperService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IQueryable<Housekeeper> RetrieveHousekeepers()
        {
            var housekeepers = _unitOfWork.Query<Housekeeper>();
            return housekeepers;
        }
    }
    
    public class MainForm
    {
        public bool HousekeeperStatementsSending { get; set; }
    }

    public class DateForm
    {
        public DateForm(string statementDate, object endOfLastMonth)
        {
        }

        public DateTime Date { get; set; }

        public DialogResult ShowDialog()
        {
            return DialogResult.Abort;
        }
    }

    public enum DialogResult
    {
        Abort,
        OK
    }

    public class SystemSettingsHelper
    {
        public static string EmailSmtpHost { get; set; }
        public static int EmailPort { get; set; }
        public static string EmailUsername { get; set; }
        public static string EmailPassword { get; set; }
        public static string EmailFromEmail { get; set; }
        public static string EmailFromName { get; set; }
    }

    public class Housekeeper
    {
        public string Email { get; set; }
        public int Oid { get; set; }
        public string FullName { get; set; }
        public string StatementEmailBody { get; set; }
    }

    public class HousekeeperStatementReport
    {
        public HousekeeperStatementReport(int housekeeperOid, DateTime statementDate)
        {
        }

        public bool HasData { get; set; }

        public void CreateDocument()
        {
        }

        public void ExportToPdf(string filename)
        {
        }
    }
    
    public class XtraMessageBox
    {
        public static void Show(string s, string housekeeperStatements, MessageBoxButtons ok)
        {
        }
    }
    
    public enum MessageBoxButtons
    {
        OK
    }
}