public class FeatureCollection
{
    // PROBLEM 5: JSON Classes
    // The root of the JSON has a "features" array
    public List<Feature> Features { get; set; }
}

public class Feature
{
    // Each feature has "properties"
    public FeatureProperties Properties { get; set; }
}

public class FeatureProperties
{
    // We specifically need the "mag" (magnitude) and "place" properties
    public double Mag { get; set; }
    public string Place { get; set; }
}