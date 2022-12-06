using System;

namespace SharpBucket.V2.Pocos
{
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Avatar
    {
        public string href { get; set; }
    }

    public class Creator
    {
        public string display_name { get; set; }
        public Links links { get; set; }
        public string type { get; set; }
        public string uuid { get; set; }
        public string account_id { get; set; }
        public string nickname { get; set; }
    }

    public class Html
    {
        public string href { get; set; }
    }

    public class Result
    {
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Pipeline
    {
        public string type { get; set; }
        public string uuid { get; set; }
        public Repository repository { get; set; }
        public State state { get; set; }
        public int build_number { get; set; }
        public Creator creator { get; set; }
        public DateTime created_on { get; set; }
        public DateTime completed_on { get; set; }
        public Target target { get; set; }
        public Trigger trigger { get; set; }
        public int run_number { get; set; }
        public int duration_in_seconds { get; set; }
        public int build_seconds_used { get; set; }
        public bool first_successful { get; set; }
        public bool expired { get; set; }
        public Links links { get; set; }
        public bool has_variables { get; set; }
    }

    public class Selector
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class State
    {
        public string name { get; set; }
        public string type { get; set; }
        public Result result { get; set; }
    }

    public class Steps
    {
        public string href { get; set; }
    }

    public class Target
    {
        public string type { get; set; }
        public string ref_type { get; set; }
        public string ref_name { get; set; }
        public Selector selector { get; set; }
        public Commit commit { get; set; }
    }

    public class Trigger
    {
        public string name { get; set; }
        public string type { get; set; }
    }
}