using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentPacker.Modules.Twitter;

public interface ITwitterClient : IDisposable
{
    Task<string> GetThread(string idConversation, string idAuthor, string? nextToken);
}
