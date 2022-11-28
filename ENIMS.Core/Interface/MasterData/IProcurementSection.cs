using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Core.Interface.MasterData
{
    public interface IProcurementSection<Response>
    {
        Response GetByRequirementPeriodId(long id);
    }
}
