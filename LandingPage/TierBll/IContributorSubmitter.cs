using LandingPage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandingPage.TierBll
{
    public interface IContributorSubmitter
    {
        Task SubmitOrder(Contributor contributor, List<Contributor> contributors);
    }
}