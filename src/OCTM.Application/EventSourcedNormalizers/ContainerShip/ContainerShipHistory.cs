using System;
using System.Collections.Generic;
using System.Linq;
using OCTM.Domain.Core.Events;
using Newtonsoft.Json;

namespace OCTM.Application.EventSourcedNormalizers.ContainerShip
{
    public class ContainerShipHistory
    {
        public static IList<ContainerShipHistoryData> HistoryData { get; set; }

        public static IList<ContainerShipHistoryData> ToJavaScriptContainerShipHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ContainerShipHistoryData>();
            ContainerShipHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<ContainerShipHistoryData>();
            var last = new ContainerShipHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new ContainerShipHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
                        ? ""
                        : change.Name,
                    Color = string.IsNullOrWhiteSpace(change.Color) || change.Color == last.Color
                        ? ""
                        : change.Color.Substring(0,10),
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void ContainerShipHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new ContainerShipHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "ContainerShipRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Capacity = values["Capacity"];
                        slot.Color = values["Color"];
                        slot.Name = values["Name"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "ContainerShipUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Color = values["Color"];
                        slot.Capacity = values["Capacity"];
                        slot.Name = values["Name"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "ContainerShipRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}