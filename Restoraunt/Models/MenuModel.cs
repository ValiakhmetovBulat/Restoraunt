using RestorauntApi.Models.Entities;

namespace Restoraunt.Models
{
    public class MenuModel
    {
        public List<MenuPosition> menuPositions { get; set; }
        private List<Section> sections { get; set; }
        private List<PositionType> positionTypes { get; set; }
        public Dictionary<string, string> typesToSections { get; set; }
        private Dictionary<int, string> typesToPositions { get; set; }
        private Dictionary<int, string> sectionsToPositions { get; set; }

        public MenuModel(List<MenuPosition> positions, List<Section> sect, List<PositionType> types)
        {
            menuPositions = positions;
            sections = sect;
            positionTypes = types;
            typesToPositions = new Dictionary<int, string>();
            sectionsToPositions = new Dictionary<int, string>();
            typesToSections = new Dictionary<string, string>();

            foreach (var position in menuPositions)
            {
                typesToPositions.Add(position.Id, position.PositionType.Name);
                sectionsToPositions.Add(position.Id, position.Section.Name);
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
