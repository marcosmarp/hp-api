﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using hp_api.DTOs;
//
//    var characterDto = CharacterDto.FromJson(jsonString);

namespace hp_api.DTOs
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CharacterSyncDTO
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("alternate_names", NullValueHandling = NullValueHandling.Ignore)]
        public string[] AlternateNames { get; set; }

        [JsonProperty("species", NullValueHandling = NullValueHandling.Ignore)]
        public string Species { get; set; }

        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public string Gender { get; set; }

        [JsonProperty("house", NullValueHandling = NullValueHandling.Ignore)]
        public string House { get; set; }

        [JsonProperty("dateOfBirth", NullValueHandling = NullValueHandling.Ignore)]
        public string DateOfBirth { get; set; }

        [JsonProperty("yearOfBirth", NullValueHandling = NullValueHandling.Ignore)]
        public long? YearOfBirth { get; set; }

        [JsonProperty("wizard", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Wizard { get; set; }

        [JsonProperty("ancestry", NullValueHandling = NullValueHandling.Ignore)]
        public string Ancestry { get; set; }

        [JsonProperty("eyeColour", NullValueHandling = NullValueHandling.Ignore)]
        public string EyeColour { get; set; }

        [JsonProperty("hairColour", NullValueHandling = NullValueHandling.Ignore)]
        public string HairColour { get; set; }

        [JsonProperty("wand", NullValueHandling = NullValueHandling.Ignore)]
        public Wand Wand { get; set; }

        [JsonProperty("patronus", NullValueHandling = NullValueHandling.Ignore)]
        public string Patronus { get; set; }

        [JsonProperty("hogwartsStudent", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HogwartsStudent { get; set; }

        [JsonProperty("hogwartsStaff", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HogwartsStaff { get; set; }

        [JsonProperty("actor", NullValueHandling = NullValueHandling.Ignore)]
        public string Actor { get; set; }

        [JsonProperty("alternate_actors", NullValueHandling = NullValueHandling.Ignore)]
        public string[] AlternateActors { get; set; }

        [JsonProperty("alive", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Alive { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Image { get; set; }
    }

    public partial class Wand
    {
        [JsonProperty("wood", NullValueHandling = NullValueHandling.Ignore)]
        public string Wood { get; set; }

        [JsonProperty("core", NullValueHandling = NullValueHandling.Ignore)]
        public string Core { get; set; }

        [JsonProperty("length", NullValueHandling = NullValueHandling.Ignore)]
        public long? Length { get; set; }
    }

    public partial class CharacterSyncDTO
    {
        public static CharacterSyncDTO FromJson(string json) => JsonConvert.DeserializeObject<CharacterSyncDTO>(json, hp_api.DTOs.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CharacterSyncDTO self) => JsonConvert.SerializeObject(self, hp_api.DTOs.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
