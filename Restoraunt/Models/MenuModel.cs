using RestorauntApi.Models.Entities;

namespace Restoraunt.Models
{
    public class MenuModel
    {
        public List<MenuPosition> menuPositions { get; set; }
        public List<Section> sections { get; set; }
        public List<PositionType> positionTypes { get; set; }
        public Dictionary<string, string> typesToSections { get; set; }
        private Dictionary<int, string> typesToPositions { get; set; }
        private Dictionary<int, string> sectionsToPositions { get; set; }

        public MenuModel(List<MenuPosition> positions, List<Section> sect, List<PositionType> types)
        {
            menuPositions = positions;
            sections = sect;
            positionTypes = types;

            foreach (var position in menuPositions)
            {
                typesToPositions.Add(position.Id, position.PositionType.Name);
                sectionsToPositions.Add(position.Id, position.PositionType.Name);
            }

            foreach (var section in sectionsToPositions)
            {
                foreach (var type in typesToPositions)
                {
                    if (section.Key == type.Key)
                    {
                        if (typesToSections.ContainsKey(type.Value))
                            continue;
                        typesToSections.Add(type.Value, section.Value);
                    }
                }
            }
        }
    }
}
