using Inoxie.Tools.Emails.Models;

namespace Inoxie.Tools.Emails.Interfaces;

public interface IEmailTemplateIdProvider<TModel>
        where TModel : BaseEmailModel, ITemplatedEmailModel
{
    string GetTemplateId(TModel model);
}
