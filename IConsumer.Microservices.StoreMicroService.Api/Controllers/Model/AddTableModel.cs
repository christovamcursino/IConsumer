using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IConsumer.Microservices.StoreMicroService.Api.Controllers.Model
{
    public class AddTableModel
    {
        public Guid StoreId { get; set; }
        public int TablesAmount { get; set; }
    }
}
