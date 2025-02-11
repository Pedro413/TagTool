using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Damage;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "model", Tag = "hlmt", Size = 0xFC, MaxVersion = CacheVersion.Halo2Vista)]
    [TagStructure(Name = "model", Tag = "hlmt", Size = 0x188, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Name = "model", Tag = "hlmt", Size = 0x1A0, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Name = "model", Tag = "hlmt", Size = 0x1B4, MaxVersion = CacheVersion.HaloOnline449175)]
    [TagStructure(Name = "model", Tag = "hlmt", Size = 0x1B8, MinVersion = CacheVersion.HaloOnline498295)]
    public partial class Model : TagStructure
	{
        public CachedTagInstance RenderModel;

        public CachedTagInstance CollisionModel;

        public CachedTagInstance Animation;

        [TagField(MaxVersion = CacheVersion.Halo2Vista)]
        public CachedTagInstance Physics;

        public CachedTagInstance PhysicsModel;

        [TagField(MaxVersion = CacheVersion.Halo2Vista)]
        public float DisappearDistance;

        [TagField(MaxVersion = CacheVersion.Halo2Vista)]
        public float BeginFadeDistance;

        [TagField(Flags = Padding, Length = 4, MaxVersion = CacheVersion.Halo2Vista)]
        public byte[] Unused1;

        public float ReduceToL1SuperLow;
        public float ReduceToL2Low;
        public float ReduceToL3Medium;
        public float ReduceToL4High;
        public float ReduceToL5SuperHigh;

        [TagField(Flags = Padding, Length = 4, MaxVersion = CacheVersion.Halo2Vista)]
        public byte[] Unused2;

        [TagField(MaxVersion = CacheVersion.Halo2Vista)]
        public ShadowFadeDistanceValue ShadowFadeDistance;

        [TagField(Flags = Padding, Length = 2, MaxVersion = CacheVersion.Halo2Vista)]
        public byte[] Unused3;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public CachedTagInstance LodModel;

        public List<Variant> Variants;

        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public List<UnknownBlock> Unknown;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public List<InstanceGroup> InstanceGroups;

        public List<Material> Materials;

        public List<GlobalDamageInfoBlock> NewDamageInfo;

        public List<Target> Targets;

        [TagField(MaxVersion = CacheVersion.Halo2Vista)]
        public List<ModelVariation> ModelVariations;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public List<UnknownTarget> UnknownTargets;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public List<CollisionRegion> CollisionRegions;

        public List<Node> Nodes;

        [TagField(Flags = Padding, Length = 4)]
        public byte[] Unused4;

        public List<ModelObjectDatum> ModelObjectData;

        public CachedTagInstance PrimaryDialogue;

        [TagField(MaxVersion = CacheVersion.Halo2Vista)]
        public CachedTagInstance ActiveCamoShader;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public CachedTagInstance SecondaryDialogue;

        public FlagsValue Flags;

        public StringId DefaultDialogueEffect;

        [TagField(Length = 8)]
        public int[] RenderOnlyNodeFlags = new int[8];

        [TagField(Length = 8)]
        public int[] RenderOnlySectionFlags = new int[8];

        public RuntimeFlagsValue RuntimeFlags;

        [TagField(MinVersion = CacheVersion.HaloOnline498295)]
        public uint Unknown3;

        public List<ScenarioLoadParametersBlock> ScenarioLoadParameters;

        [TagField(MaxVersion = CacheVersion.Halo2Vista)]
        public CachedTagInstance HologramShader;

        [TagField(MaxVersion = CacheVersion.Halo2Vista)]
        public StringId HologramControlFunction;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public sbyte UnknownIndex1;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public sbyte UnknownIndex2;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public short Unknown5;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public List<UnknownBlock2> Unknown6;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public List<UnknownBlock3> Unknown7;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public List<UnknownBlock4> Unknown8;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public CachedTagInstance ShieldImpactThirdPerson;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public CachedTagInstance ShieldImpactFirstPerson;

        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public CachedTagInstance OvershieldThirdPerson;

        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public CachedTagInstance OvershieldFirstPerson;

        public enum ShadowFadeDistanceValue : short
        {
            FadeAtSuperHighDetailLevel,
            FadeAtHighDetailLevel,
            FadeAtMediumDetailLevel,
            FadeAtLowDetailLevel,
            FadeAtSuperLowDetailLevel,
            FadeNever
        }

        [TagStructure(Size = 0x38, MaxVersion = CacheVersion.Halo2Vista)]
        [TagStructure(Size = 0x38, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x50, MinVersion = CacheVersion.Halo3ODST)]
        public class Variant : TagStructure
		{
            public StringId Name;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public CachedTagInstance VariantDialogue;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public StringId DefaultDialogEffect;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown2;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown3;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown4;

            [TagField(MinVersion = CacheVersion.HaloOnline700123)]
            public StringId SkinName;

            [TagField(Length = 16)]
            public sbyte[] ModelRegionIndices = new sbyte[16];

            public List<Region> Regions;
            public List<Object> Objects;

            public int InstanceGroupIndex;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public StringId DialogueSoundEffect;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public CachedTagInstance Dialogue;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public uint Unknown6;

            [TagField(MaxVersion = CacheVersion.HaloOnline571627)]
            public uint Unknown7;

            [TagStructure(Size = 0x14, MaxVersion = CacheVersion.Halo2Vista)]
            [TagStructure(Size = 0x18, MinVersion = CacheVersion.Halo3Retail)]
            public class Region : TagStructure
			{
                public StringId Name;

                [TagField(MinVersion = CacheVersion.Halo3Retail)]
                public sbyte RenderModelRegionIndex;

                [TagField(MinVersion = CacheVersion.Halo3Retail)]
                public sbyte Unknown;

                public short ParentVariant;

                [TagField(Flags = Padding, Length = 2, MaxVersion = CacheVersion.Halo2Vista)]
                public byte[] Unused = new byte[2];

                public List<Permutation> Permutations;

                public SortOrderValue SortOrder;

                [TagStructure(Size = 0x20, MaxVersion = CacheVersion.Halo2Vista)]
                [TagStructure(Size = 0x24, MinVersion = CacheVersion.Halo3Retail)]
                public class Permutation : TagStructure
				{
                    public StringId Name;

                    [TagField(MinVersion = CacheVersion.Halo3Retail)]
                    public sbyte RenderModelPermutationIndex;

                    public FlagsValue Flags;

                    public byte Unknown1;
                    public byte Unknown2;

                    [TagField(MaxVersion = CacheVersion.Halo2Vista)]
                    public byte Unknown3;

                    public float Probability;
                    public List<State> States;

                    [TagField(Length = 12, MinVersion = CacheVersion.Halo3Retail)]
                    public sbyte[] RuntimeStatePermutationIndices = new sbyte[12];

                    [Flags]
                    public enum FlagsValue : byte
                    {
                        None,
                        CopyStatesToAllPermutations = 1 << 0
                    }

                    [TagStructure(Size = 0x18, MaxVersion = CacheVersion.Halo2Vista)]
                    [TagStructure(Size = 0x20, MinVersion = CacheVersion.Halo3Retail)]
                    public class State : TagStructure
					{
                        public StringId Name;
                        public byte ModelPermutationIndex;
                        public PropertyFlagsValue PropertyFlags;
                        public StateValue State2;
                        public CachedTagInstance LoopingEffect;
                        public StringId LoopingEffectMarkerName;
                        public float InitialProbability;

                        [Flags]
                        public enum PropertyFlagsValue : byte
                        {
                            None = 0,
                            Blurred = 1 << 0,
                            HellaBlurred = 1 << 1,
                            Shielded = 1 << 2,
                            Bit3 = 1 << 3,
                            Bit4 = 1 << 4,
                            Bit5 = 1 << 5,
                            Bit6 = 1 << 6,
                            Bit7 = 1 << 7
                        }

                        public enum StateValue : short
                        {
                            Default,
                            MinorDamage,
                            MediumDamage,
                            MajorDamage,
                            Destroyed
                        }
                    }
                }

                public enum SortOrderValue : int
                {
                    NoSorting,
                    _5Closest,
                    _4,
                    _3,
                    _2,
                    _1,
                    _0SameAsModel,
                    _1_2,
                    _2_2,
                    _3_2,
                    _4_2,
                    _5Farthest,
                }
            }

            [TagStructure(Size = 0x10, MaxVersion = CacheVersion.Halo2Vista)]
            [TagStructure(Size = 0x1C, MinVersion = CacheVersion.Halo3Retail)]
            public class Object : TagStructure
			{
                public StringId ParentMarker;
                public StringId ChildMarker;

                [TagField(MinVersion = CacheVersion.Halo3Retail)]
                public StringId ChildVariant;

                public CachedTagInstance ChildObject;
            }
        }

        [TagStructure(Size = 0x4)]
        public class UnknownBlock : TagStructure
		{
            public uint Unknown;
        }

        [TagStructure(Size = 0x18)]
        public class InstanceGroup : TagStructure
		{
            public StringId Name;
            public ChoiceValue Choice;
            public List<InstanceMember> InstanceMembers;
            public float Probability;

            public enum ChoiceValue : int
            {
                ChooseOneMember,
                ChooseAllMembers
            }

            [TagStructure(Size = 0x14, MaxVersion = CacheVersion.Halo3Retail)]
            [TagStructure(Size = 0x1C, MinVersion = CacheVersion.Halo3ODST)]
            public class InstanceMember : TagStructure
			{
                public int SubgroupIndex;
                public StringId InstanceName;
                public float Probability;

                [TagField(Length = 2)]
                public int[] InstanceFlags = new int[2];

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public uint Unknown4;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public uint Unknown5;
            }
        }

        [TagStructure(Size = 0x14)]
        public class Material : TagStructure
		{
            public StringId Name;
            public MaterialTypeValue MaterialType;
            public short DamageSectionIndex;
            public short RuntimeCollisionMaterialIndex;
            public short RuntimeDamagerMaterialIndex;
            public StringId MaterialName;
            public short GlobalMaterialIndex;

            [TagField(Flags = Padding, Length = 2)]
            public byte[] Unused = new byte[2];

            public enum MaterialTypeValue : short
            {
                Dirt,
                Sand,
                Stone,
                Snow,
                Wood,
                Metalhollow,
                Metalthin,
                Metalthick,
                Rubber,
                Glass,
                ForceField,
                Grunt,
                HunterArmor,
                HunterSkin,
                Elite,
                Jackal,
                JackalEnergyShield,
                EngineerSkin,
                EngineerForceField,
                FloodCombatForm,
                FloodCarrierForm,
                CyborgArmor,
                CyborgEnergyShield,
                HumanArmor,
                HumanSkin,
                Sentinel,
                Monitor,
                Plastic,
                Water,
                Leaves,
                EliteEnergyShield,
                Ice,
                HunterShield
            }
        }

        [TagStructure(Size = 0xF8, MaxVersion = CacheVersion.Halo2Vista)]
        [TagStructure(Size = 0x100, MinVersion = CacheVersion.Halo3Retail)]
        public class GlobalDamageInfoBlock : TagStructure
		{
            public FlagsValue Flags;

            /// <summary>
            /// Absorbes AOE or child damage
            /// </summary>
            public StringId GlobalIndirectMaterialName;

            /// <summary>
            /// Absorbes AOE or child damage
            /// </summary>
            public short IndirectDamageSection;

            [TagField(Flags = Padding, Length = 6)]
            public byte[] Unused1 = new byte[6];

            public DamageReportingType CollisionDamageReportingType;

            [TagField(Flags = Padding, Length = 1, MaxVersion = CacheVersion.Halo2Vista)]
            public byte[] Unused2 = new byte[1];

            public DamageReportingType ResponseDamageReportingType;

            [TagField(Flags = Padding, Length = 1, MaxVersion = CacheVersion.Halo2Vista)]
            public byte[] Unused3 = new byte[1];

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public short Unknown4;

            [TagField(Flags = Padding, Length = 20)]
            public byte[] Unused5 = new byte[20];

            public float MaxVitality;
            public float MinStunDamage;
            public float StunTime;
            public float RechargeTime;
            public float RechargeFraction;

            [TagField(Flags = Padding, Length = 64)]
            public byte[] Unused6 = new byte[64];

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public CachedTagInstance ShieldDamagedFirstPersonShader;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public CachedTagInstance ShieldDamagedShader;

            public float MaxShieldVitality;
            public StringId GlobalShieldMaterialName;
            public float MinStunDamage2;
            public float StunTime2;
            public float ShieldRechargeTime;
            public float ShieldDamagedThreshold;
            public CachedTagInstance ShieldDamagedEffect;
            public CachedTagInstance ShieldDepletedEffect;
            public CachedTagInstance ShieldRechargingEffect;
            public List<DamageSection> DamageSections;
            public List<Node> Nodes;
            public short GlobalShieldMaterialIndex;
            public short GlobalIndirectMaterialIndex;
            public uint Unknown1;
            public uint Unknown2;
            public List<DamageSeat> DamageSeats;
            public List<DamageConstraint> DamageConstraints;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public CachedTagInstance OvershieldFirstPersonShader;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public CachedTagInstance OvershieldShader;

            [Flags]
            public enum FlagsValue : int
            {
                None,
                TakesShieldDamageForChildren = 1 << 0,
                TakesBodyDamageForChildren = 1 << 1,
                AlwaysShieldsFriendlyDamage = 1 << 2,
                PassesAreaDamageToChildren = 1 << 3,
                ParentNeverTakesBodyDamageForChildren = 1 << 4,
                OnlyDamagedByExplosives = 1 << 5,
                ParentNeverTakesShieldDamageForChildren = 1 << 6,
                CannotDieFromDamage = 1 << 7,
                PassesAttachedDamageToRiders = 1 << 8,
                ShieldDepletionIsPermanent = 1 << 9,
                ShieldDepletionForceHardPing = 1 << 10,
                AiDoNotDamageWithoutPlayer = 1 << 11,
                HealthRegrowsWhileDead = 1 << 12,
                ShieldRechargePlaysOnlyWhenEmpty = 1 << 13,
                IgnoreForceMinimumTransfer = 1 << 14,
                OrphanFromPostprocessAutogen = 1 << 15,
                OnlyDamagedByBoardingDamage = 1 << 16
            }

            [TagStructure(Size = 0x38, MaxVersion = CacheVersion.Halo2Vista)]
            [TagStructure(Size = 0x44, MinVersion = CacheVersion.Halo3Retail)]
            public class DamageSection : TagStructure
			{
                public StringId Name;
                public FlagsValue Flags;
                public float VitalityPercentage;
                public List<InstantResponse> InstantResponses;

                [TagField(Flags = Padding, Length = 20)]
                public byte[] Unused1 = new byte[20];

                [TagField(MinVersion = CacheVersion.Halo3Retail)]
                public uint Unknown1;

                public float StunTime;
                public float RechargeTime;

                [TagField(MinVersion = CacheVersion.Halo3Retail)]
                public uint Unknown2;

                public StringId ResurrectionRegionName;
                public short RessurectionRegionRuntimeIndex;

                [TagField(Flags = Padding, Length = 2)]
                public byte[] Unused2 = new byte[2];

                [Flags]
                public enum FlagsValue : int
                {
                    None,
                    AbsorbsBodyDamage = 1 << 0,
                    TakesFullDamageWhenObjectDies = 1 << 1,
                    CannotDieWithRiders = 1 << 2,
                    TakesFullDamageWhenObjectDestroyed = 1 << 3,
                    RestoredOnRessurection = 1 << 4,
                    Unused5 = 1 << 5,
                    Unused6 = 1 << 6,
                    Headshotable = 1 << 7,
                    IgnoresShields = 1 << 8,
                    TakesFullDamageWhenShieldDepleted = 1 << 9,
                    Networked = 1 << 10,
                    AllowDamageResponseOverflow = 1 << 11
                }

                [TagStructure(Size = 0x50, MaxVersion = CacheVersion.Halo2Vista)]
                [TagStructure(Size = 0x88, MinVersion = CacheVersion.Halo3Retail)]
                public class InstantResponse : TagStructure
				{
                    public ResponseTypeValue ResponseType;
                    public ConstraintDamageTypeValue ConstraintDamageType;

                    [TagField(MinVersion = CacheVersion.Halo3Retail)]
                    public StringId Trigger;

                    public FlagsValue Flags;
                    public float DamageThreshold;
                    public CachedTagInstance PrimaryTransitionEffect;

                    [TagField(MinVersion = CacheVersion.Halo3Retail)]
                    public CachedTagInstance SecondaryTransitionEffect;

                    public CachedTagInstance TransitionDamageEffect;
                    public StringId Region;
                    public NewStateValue NewState;
                    public short RuntimeRegionIndex;

                    [TagField(MinVersion = CacheVersion.Halo3Retail)]
                    public StringId SecondaryRegion;

                    [TagField(MinVersion = CacheVersion.Halo3Retail)]
                    public NewStateValue SecondaryNewState;

                    [TagField(MinVersion = CacheVersion.Halo3Retail)]
                    public short SecondaryRuntimeRegionIndex;

                    [TagField(MinVersion = CacheVersion.Halo3Retail)]
                    public short Unknown; // ???

                    [TagField(MinVersion = CacheVersion.Halo3Retail)]
                    public UnknownSpecialDamageValue UnknownSpecialDamage;

                    [TagField(MinVersion = CacheVersion.Halo3Retail)]
                    public StringId SpecialDamageCase;

                    public StringId EffectMarkerName;
                    public StringId DamageEffectMarkerName;
                    public float ResponseDelay;
                    public CachedTagInstance DelayEffect;
                    public StringId DelayEffectMarkerName;

                    [TagField(MaxVersion = CacheVersion.Halo2Vista)]
                    public StringId ConstraintGroupName;

                    public StringId EjectingSeatLabel;
                    public float SkipFraction;
                    public StringId DestroyedChildObjectMarkerName;
                    public float TotalDamageThreshold;

                    public enum ResponseTypeValue : short
                    {
                        RecievesAllDamage,
                        RecievesAreaEffectDamage,
                        RecievesLocalDamage
                    }

                    public enum ConstraintDamageTypeValue : short
                    {
                        None,
                        DestroyOneOfGroup,
                        DestroyEntireGroup,
                        LoosenOneOfGroup,
                        LoosenEntireGroup
                    }

                    [Flags]
                    public enum FlagsValue : int
                    {
                        None,

                        /// <summary>
                        /// When the response fires the object dies regardless of its current health.
                        /// </summary>
                        KillsObject = 1 << 0,

                        /// <summary>
                        /// From halo 1 - disallows melee for a unit.
                        /// </summary>
                        InhibitsMeleeAttack = 1 << 1,

                        /// <summary>
                        /// From halo 1 - disallows weapon fire for a unit.
                        /// </summary>
                        InhibitsWeaponAttack = 1 << 2,

                        /// <summary>
                        /// From halo 1 - disallows walking for a unit.
                        /// </summary>
                        InhibitsWalking = 1 << 3,

                        /// <summary>
                        /// From halo 1 - makes the unit drop its current weapon.
                        /// </summary>
                        ForcesDropWeapon = 1 << 4,

                        KillsWeaponPrimaryTrigger = 1 << 5,
                        KillsWeaponSecondaryTrigger = 1 << 6,

                        /// <summary>
                        /// When the response fires the object is destroyed.
                        /// </summary>
                        DestroysObject = 1 << 7,

                        /// <summary>
                        /// Destroys the primary trigger on the unit's current weapon.
                        /// </summary>
                        DamagesWeaponPrimaryTrigger = 1 << 8,

                        /// <summary>
                        /// Destroys the secondary trigger on the unit's current weapon.
                        /// </summary>
                        DamagesWeaponSecondaryTrigger = 1 << 9,

                        LightDamageLeftTurn = 1 << 10,
                        MajorDamageLeftTurn = 1 << 11,
                        LightDamageRightTurn = 1 << 12,
                        MajorDamageRightTurn = 1 << 13,
                        LightDamageEngine = 1 << 14,
                        MajorDamageEngine = 1 << 15,
                        KillsObjectNoPlayerSolo = 1 << 16,
                        CausesDetonation = 1 << 17,
                        FiresOnCreation = 1 << 18,
                        KillsVariantObjects = 1 << 19,
                        ForceUnattachedEffects = 1 << 20,
                        FiresUnderThreshold = 1 << 21,
                        TriggersSpecialDeath = 1 << 22,
                        OnlyOnSpecialDeath = 1 << 23,
                        OnlyNotOnSpecialDeath = 1 << 24,
                        BucklesGiants = 1 << 25,
                        CausesSpDetonation = 1 << 26,
                        SkipSoundsOnGenericEffect = 1 << 27,
                        KillsGiants = 1 << 28,
                        SkipSoundsOnSpecialDeath = 1 << 29,
                        CauseHeadDismemberment = 1 << 30,
                        CauseLeftLegDismemberment = 1 << 31
                    }

                    public enum NewStateValue : short
                    {
                        Default,
                        MinorDamage,
                        MediumDamage,
                        MajorDamage,
                        Destroyed
                    }
                    
                    public enum UnknownSpecialDamageValue : short
                    {
                        None,
                        Primary,
                        Secondary,
                        Tertiary
                    }
                }
            }

            [TagStructure(Size = 0x10)]
            public class Node : TagStructure
			{
                public short Unknown;
                public short Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x14, MaxVersion = CacheVersion.Halo2Vista)]
            [TagStructure(Size = 0x20, MinVersion = CacheVersion.Halo3Retail)]
            public class DamageSeat : TagStructure
			{
                public StringId SeatLabel;
                public float DirectDamageScale;
                public float DamageTransferFallOffRadius;
                public float MaximumTransferDamageScale;
                public float MinimumTransferDamageScale;

                [TagField(MinVersion = CacheVersion.Halo3Retail)]
                public List<RegionSpecificDamageBlock> RegionSpecificDamage;

                [TagStructure(Size = 0x2C)]
                public class RegionSpecificDamageBlock : TagStructure
				{
                    public StringId DamageRegionName;
                    public short RuntimeDamageRegionIndex;

                    [TagField(Flags = Padding, Length = 2)]
                    public short Unused;

                    public float DirectDamageScaleMinor;
                    public float MaxTransferScaleMinor;
                    public float MinTransferScaleMinor;

                    public float DirectDamageScaleMedium;
                    public float MaxTransferScaleMedium;
                    public float MinTransferScaleMedium;

                    public float DirectDamageScaleMajor;
                    public float MaxTransferScaleMajor;
                    public float MinTransferScaleMajor;
                }
            }

            [TagStructure(Size = 0x14)]
            public class DamageConstraint : TagStructure
			{
                public StringId PhysicsModelConstraintName;
                public StringId DamageConstraintName;
                public StringId DamageConstraintGroupName;
                public float GroupProbabilityScale;
                public TypeValue Type;
                public short Index;

                public enum TypeValue : short
                {
                    Hinge,
                    LimitedHinge,
                    Ragdoll,
                    StiffSpring,
                    BallAndSocket,
                    Prismatic
                }
            }
        }

        [TagStructure(Size = 0x1C, MaxVersion = CacheVersion.Halo2Vista)]
        [TagStructure(Size = 0x20, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloOnline106708)]
        public class Target : TagStructure
		{
            [TagField(MinVersion = CacheVersion.HaloOnline106708)]
            public uint Unknown;

            public StringId MarkerName;
            public float Size;
            public Angle ConeAngle;
            public short DamageSection;
            public short Variant;
            public float TargetingRelevance;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public uint Unknown2;

            public FlagsValue Flags;
            public float LockOnDistance;

            [TagField(MinVersion = CacheVersion.HaloOnline106708)]
            public StringId TargetFilter;

            [Flags]
            public enum FlagsValue : int
            {
                None = 0,
                LockedByHumanTracking = 1 << 0,
                LockedByPlasmaTracking = 1 << 1,
                Headshot = 1 << 2,
                Bit3 = 1 << 3,
                Vulnerable = 1 << 4,
                Bit5 = 1 << 5,
                AlwaysLockedByPlasmaTracking = 1 << 6,
                Bit7 = 1 << 7,
                Bit8 = 1 << 8,
                Bit9 = 1 << 9,
                Bit10 = 1 << 10,
                Bit11 = 1 << 11,
                Bit12 = 1 << 12,
                Bit13 = 1 << 13,
                Bit14 = 1 << 14,
                Bit15 = 1 << 15,
                Bit16 = 1 << 16,
                Bit17 = 1 << 17,
                Bit18 = 1 << 18,
                Bit19 = 1 << 19,
                Bit20 = 1 << 20,
                Bit21 = 1 << 21,
                Bit22 = 1 << 22,
                Bit23 = 1 << 23,
                Bit24 = 1 << 24,
                Bit25 = 1 << 25,
                Bit26 = 1 << 26,
                Bit27 = 1 << 27,
                Bit28 = 1 << 28,
                Bit29 = 1 << 29,
                Bit30 = 1 << 30,
                Bit31 = 1 << 31
            }
        }

        [TagStructure(Size = 0x10)]
        public class ModelVariation : TagStructure
        {
            public StringId Type;
            public uint Unknown;
            public List<Permutation> Permutations;

            [TagStructure(Size = 0x4)]
            public class Permutation : TagStructure
            {
                public StringId Variation;
            }
        }

        [TagStructure(Size = 0x10, MaxVersion = CacheVersion.Halo2Vista)]
        [TagStructure(Size = 0x14, MinVersion = CacheVersion.Halo3Retail)]
        public class CollisionRegion : TagStructure
		{
            public StringId Name;
            public sbyte CollisionRegionIndex;
            public sbyte PhysicsRegionIndex;
            public sbyte Unknown;
            public sbyte Unknown2;
            public List<Permutation> Permutations;

            [TagStructure(Size = 0x8)]
            public class Permutation : TagStructure
			{
                public StringId Name;
                public FlagsValue Flags;
                public sbyte CollisionPermutationIndex;
                public sbyte PhysicsPermutationIndex;
                public sbyte Unknown;

                [Flags]
                public enum FlagsValue : byte
                {
                    None = 0,
                    CannotBeChosenRandomly = 1 << 0,
                    Bit1 = 1 << 1,
                    Bit2 = 1 << 2,
                    Bit3 = 1 << 3,
                    Bit4 = 1 << 4,
                    Bit5 = 1 << 5,
                    Bit6 = 1 << 6,
                    Bit7 = 1 << 7
                }
            }
        }

        [TagStructure(Size = 0x5C)]
        public class Node : TagStructure
		{
            public StringId Name;
            public short ParentNode;
            public short FirstChildNode;
            public short NextSiblingNode;
            public short ImportNodeIndex;
            public RealPoint3d DefaultTranslation;
            public RealQuaternion DefaultRotation;
            public float DefaultScale;
            public RealMatrix4x3 Inverse;
        }

        [TagStructure(Size = 0x14)]
        public class ModelObjectDatum : TagStructure
		{
            public TypeValue Type;
            public short Unknown;
            public RealPoint3d Offset;
            public float Radius;

            public enum TypeValue : short
            {
                NotSet,
                UserDefined,
                AutoGenerated
            }
        }

        [Flags]
        public enum FlagsValue : int
        {
            None = 0,
            ActiveCamoAlwaysOn = 1 << 0,
            ActiveCamoAlwaysMerge = 1 << 1,
            ActiveCamoNeverMerge = 1 << 2,
            InconsequentialTarget = 1 << 3,
            LockedPrecomputedProbes = 1 << 4,
            ModelIsBigBattleObject = 1 << 5,
            ModelNeverUsesCompressedVertexPositions = 1 << 6,
            ModelIsInvisibleEvenAttachments = 1 << 7,
            Bit8 = 1 << 8,
            Bit9 = 1 << 9,
            Bit10 = 1 << 10,
            Bit11 = 1 << 11,
            Bit12 = 1 << 12,
            Bit13 = 1 << 13,
            Bit14 = 1 << 14,
            Bit15 = 1 << 15,
            Bit16 = 1 << 16,
            Bit17 = 1 << 17,
            Bit18 = 1 << 18,
            Bit19 = 1 << 19,
            Bit20 = 1 << 20,
            Bit21 = 1 << 21,
            Bit22 = 1 << 22,
            Bit23 = 1 << 23,
            Bit24 = 1 << 24,
            Bit25 = 1 << 25,
            Bit26 = 1 << 26,
            Bit27 = 1 << 27,
            Bit28 = 1 << 28,
            Bit29 = 1 << 29,
            Bit30 = 1 << 30,
            Bit31 = 1 << 31
        }

        [Flags]
        public enum RuntimeFlagsValue : int
        {
            None,
            ContainsRuntimeNodes = 1 << 0,
            Bit1 = 1 << 1,
            Bit2 = 1 << 2,
            Bit3 = 1 << 3,
            Bit4 = 1 << 4,
            Bit5 = 1 << 5,
            Bit6 = 1 << 6,
            Bit7 = 1 << 7,
            Bit8 = 1 << 8,
            Bit9 = 1 << 9,
            Bit10 = 1 << 10,
            Bit11 = 1 << 11,
            Bit12 = 1 << 12,
            Bit13 = 1 << 13,
            Bit14 = 1 << 14,
            Bit15 = 1 << 15,
            Bit16 = 1 << 16,
            Bit17 = 1 << 17,
            Bit18 = 1 << 18,
            Bit19 = 1 << 19,
            Bit20 = 1 << 20,
            Bit21 = 1 << 21,
            Bit22 = 1 << 22,
            Bit23 = 1 << 23,
            Bit24 = 1 << 24,
            Bit25 = 1 << 25,
            Bit26 = 1 << 26,
            Bit27 = 1 << 27,
            Bit28 = 1 << 28,
            Bit29 = 1 << 29,
            Bit30 = 1 << 30,
            Bit31 = 1 << 31
        }

        [TagStructure(Size = 0x44)]
        public class ScenarioLoadParametersBlock : TagStructure
		{
            public CachedTagInstance Scenario;
            public byte[] Data;

            [TagField(Flags = Padding, Length = 32)]
            public byte[] Unused;
        }

        [TagStructure(Size = 0x8)]
        public class UnknownBlock2 : TagStructure
		{
            public StringId Region;
            public StringId Permutation;
        }

        [TagStructure(Size = 0x8)]
        public class UnknownBlock3 : TagStructure
		{
            public StringId Unknown;
            public uint Unknown2;
        }

        [TagStructure(Size = 0x14)]
        public class UnknownBlock4 : TagStructure
		{
            public StringId Marker;
            public uint Unknown;
            public StringId Marker2;
            public uint Unknown2;
            public uint Unknown3;
        }

        [TagStructure(Size = 0x8)]
        public class UnknownTarget : TagStructure
		{
            public StringId MarkerName;
            public float Unknown;
        }
    }
}