using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BregisDigitalConverterServiceObject.SystemObjects
{
  public class MailMessageObject
    {
      public int MailMessageIndex
      {
          get;
          set;
      }

      public string MailMessageId
      {
          get;
          set;
      }

      public string MailFrom
      {
          get;
          set;
      }

      public string MailTo
      {
          get;
          set;
      }

      public string MailSubject
      {
          get;
          set;
      }

      public string MailMessageStr
      {
          get;
          set;
      }

      public DateTime MailMessageDate
      {
          get;
          set;
      }

      public List<CMailAttachmentClass> pAttachementFileList;

      public MailMessageObject(
          int pMailMessageIndex,
          string pMailMessageId,
          string pMailMessageFrom,
          string pMailMessageTo,
          string pMailMessageSubject,
          string pMailMessageText,
          DateTime pMessageDate,
          List<CMailAttachmentClass> pAttachmentList)
      {
          MailMessageIndex = pMailMessageIndex;
          MailMessageId = pMailMessageId;
          MailFrom = pMailMessageFrom;
          MailTo = pMailMessageTo;
          MailSubject = pMailMessageSubject;
          MailMessageStr = pMailMessageText;
          pAttachementFileList = pAttachmentList;
      }

      public MailMessageObject(int pMailMessageIndex,
          string pMailMessageId,
        string pMailMessageFrom,
        string pMailMessageTo,
        string pMailMessageSubject,
        string pMailMessageText,
        DateTime pMessageDate)
      {
          MailMessageIndex = pMailMessageIndex;
          MailMessageId = pMailMessageId;
          MailFrom = pMailMessageFrom;
          MailTo = pMailMessageTo;
          MailSubject = pMailMessageSubject;
          MailMessageStr = pMailMessageText;
          pAttachementFileList = new List<CMailAttachmentClass>();
      }

      public void AddAttachmentToMailMessage(int pIndex, string pFileName)
      {
          CMailAttachmentClass pMailAttachment = new CMailAttachmentClass(pIndex, pFileName);
          pAttachementFileList.Add(pMailAttachment);
      }
    }
}
