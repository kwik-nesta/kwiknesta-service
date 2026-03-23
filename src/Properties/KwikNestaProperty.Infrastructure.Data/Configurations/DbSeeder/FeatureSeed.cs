using KwikNesta.Shared.Models.Enumerations.Property;

namespace KwikNestaProperty.Infrastructure.Data.Configurations.DbSeeder
{
    public static class FeatureSeed
    {
        public static readonly List<(Guid Id, string Name, EFeatureCategory Category)> FeaturesToSeed = new()
        {
            (AirConditioning, "Air Conditioning", EFeatureCategory.Interior),
            (Furnished, "Furnished", EFeatureCategory.Interior),
            (SemiFurnished, "Semi-Furnished", EFeatureCategory.Interior),
            (BuiltInWardrobes, "Built-in Wardrobes", EFeatureCategory.Interior),
            (SmartHomeSystem, "Smart Home System", EFeatureCategory.Interior),
            (LaundryRoom, "Laundry Room", EFeatureCategory.Interior),

            (Balcony, "Balcony", EFeatureCategory.Exterior),
            (Terrace, "Terrace", EFeatureCategory.Exterior),
            (Garden, "Garden", EFeatureCategory.Exterior),
            (Fence, "Fence", EFeatureCategory.Exterior),
            (GatedCompound, "Gated Compound", EFeatureCategory.Exterior),

            (CCTV, "CCTV", EFeatureCategory.Security),
            (SecurityDoors, "Security Doors", EFeatureCategory.Security),
            (BurglarAlarm, "Burglar Alarm", EFeatureCategory.Security),
            (GatedEstate, "Gated Estate", EFeatureCategory.Security),
            (Security, "Security", EFeatureCategory.Security),

            (Electricity, "Electricity", EFeatureCategory.Utilities),
            (PrepaidMeter, "Prepaid Meter", EFeatureCategory.Utilities),
            (BoysQuarters, "Boys Quarters", EFeatureCategory.Utilities),
            (Electricity, "Electricity", EFeatureCategory.Utilities),
            (Generator, "Generator", EFeatureCategory.Utilities),
            (Inverter, "Inverter", EFeatureCategory.Utilities),
            (Borehole, "Borehole", EFeatureCategory.Utilities),
            (WaterSuply, "Water Suply", EFeatureCategory.Utilities),
            (CableTV, "Cable TV", EFeatureCategory.Utilities),
            (Internet, "Internet", EFeatureCategory.Utilities),
            (ParkingSpace, "Parking Space", EFeatureCategory.Utilities),
            (SwimmingPool, "Swimming Pool", EFeatureCategory.Utilities),
            (Gym, "Gym", EFeatureCategory.Utilities),
            (Jacuzzi, "Jacuzzi", EFeatureCategory.Utilities),
            (Garage, "Garage", EFeatureCategory.Utilities),
            (Elevator, "Elevator", EFeatureCategory.Utilities)
        };

        //Interior
        private static readonly Guid AirConditioning = Guid.Parse("9BED23D9-8F16-4444-83D3-9A114A8E42F3");
        private static readonly Guid Furnished = Guid.Parse("8BED23D9-8F16-4444-83D3-9A114A8E42F4");
        private static readonly Guid SemiFurnished = Guid.Parse("7BED23D9-8F16-4444-83D3-9A114A8E42F5");
        private static readonly Guid BuiltInWardrobes = Guid.Parse("6BED23D9-8F16-4444-83D3-9A114A8E42F6");
        private static readonly Guid SmartHomeSystem = Guid.Parse("5BED23D9-8F16-4444-83D3-9A114A8E42F7");
        private static readonly Guid LaundryRoom = Guid.Parse("4BED23D9-8F16-4444-83D3-9A114A8E42F8");
        //Exterior
        private static readonly Guid Balcony = Guid.Parse("3BED23D9-8F16-4444-83D3-9A114A8E42F9");
        private static readonly Guid Terrace = Guid.Parse("2BED23D9-8F16-4444-83D3-9A114A8E42F0");
        private static readonly Guid Garden = Guid.Parse("1BED23D9-8F16-4444-83D3-9A114A8E42F1");
        private static readonly Guid Fence = Guid.Parse("0BED23D9-8F16-4444-83D3-9A114A8E42F2");
        private static readonly Guid GatedCompound = Guid.Parse("ABED23D9-8F16-4444-83D3-9A114A8E42FA");
        //Security
        private static readonly Guid CCTV = Guid.Parse("BBED23D9-8F16-4444-83D3-9A114A8E42FB");
        private static readonly Guid SecurityDoors = Guid.Parse("CBED23D9-8F16-4444-83D3-9A114A8E42FB");
        private static readonly Guid BurglarAlarm = Guid.Parse("DBED23D9-8F16-4444-83D3-9A114A8E42FC");
        private static readonly Guid GatedEstate = Guid.Parse("EBED23D9-8F16-4444-83D3-9A114A8E42FD");
        private static readonly Guid Security = Guid.Parse("ECED23D9-8F16-4444-83D3-9A114A8E42FE");
        //Utilities
        private static readonly Guid Electricity = Guid.Parse("EDED23D9-8F16-4444-83D3-9A114A8E420E");
        private static readonly Guid PrepaidMeter = Guid.Parse("EEED23D9-8F16-4444-83D3-9A114A8E421E");
        private static readonly Guid BoysQuarters = Guid.Parse("E0ED23D9-8F16-4444-83D3-9A114A8E422E");
        private static readonly Guid Generator = Guid.Parse("E1ED23D9-8F16-4444-83D3-9A114A8E423E");
        private static readonly Guid Inverter = Guid.Parse("E2ED23D9-8F16-4444-83D3-9A114A8E424E");
        private static readonly Guid Borehole = Guid.Parse("E3ED23D9-8F16-4444-83D3-9A114A8E425E");
        private static readonly Guid WaterSuply = Guid.Parse("E4ED23D9-8F16-4444-83D3-9A114A8E426E");
        private static readonly Guid CableTV = Guid.Parse("E5ED23D9-8F16-4444-83D3-9A114A8E427E");
        private static readonly Guid Internet = Guid.Parse("E6ED23D9-8F16-4444-83D3-9A114A8E428E");
        private static readonly Guid ParkingSpace = Guid.Parse("E7ED23D9-8F16-4444-83D3-9A114A8E429E");
        private static readonly Guid SwimmingPool = Guid.Parse("E8ED23D9-8F16-4444-83D3-9A114A8E4200");
        private static readonly Guid Gym = Guid.Parse("E9ED23D9-8F16-4444-83D3-9A114A8E4201");
        private static readonly Guid Jacuzzi = Guid.Parse("00ED23D9-8F16-4444-83D3-9A114A8E4202");
        private static readonly Guid Garage = Guid.Parse("01ED23D9-8F16-4444-83D3-9A114A8E4203");
        private static readonly Guid Elevator = Guid.Parse("02ED23D9-8F16-4444-83D3-9A114A8E4204");
    }
}