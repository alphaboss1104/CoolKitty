﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPlugins.Core.DomainModel
{
    public class Version : IComparer<Version>
    {
        public Version(string versionNumber)
        {
            this.VersionNumber = versionNumber;
        }

        public int PrimaryVersion
        {
            get
            {
                return Convert.ToInt32(this.VersionNumber.Split('.')[0]);
            }
        }

        public int SecondaryVersion
        {
            get
            {
                return Convert.ToInt32(this.VersionNumber.Split('.')[1]);
            }
        }

        public int MinorVersion
        {
            get
            {
                return Convert.ToInt32(this.VersionNumber.Split('.')[2]);
            }
        }

        public string VersionNumber { get; set; }

        public int Compare(Version x, Version y)
        {
            if (x.PrimaryVersion > y.PrimaryVersion
                || (x.PrimaryVersion == y.PrimaryVersion && x.SecondaryVersion > y.SecondaryVersion)
                || (x.PrimaryVersion == y.PrimaryVersion && x.SecondaryVersion == y.SecondaryVersion && x.MinorVersion > y.MinorVersion))
            {
                return 1;
            }
            else if (x.PrimaryVersion == y.PrimaryVersion
                && x.SecondaryVersion == y.SecondaryVersion
                && x.MinorVersion == y.MinorVersion)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public static bool operator ==(Version left, Version right)
        {
            if (left == null || right == null)
            {
                return false;
            }

            return left.VersionNumber.Equals(right.VersionNumber);
        }

        public static bool operator !=(Version left, Version right)
        {
            return !(left == right);
        }

        public static implicit operator Version(string versionNumber)
        {
            return new Version(versionNumber);
        }

        public static bool operator >(Version x, Version y)
        {
            return x.PrimaryVersion > y.PrimaryVersion ||
                (x.PrimaryVersion == y.PrimaryVersion && x.SecondaryVersion > y.SecondaryVersion)
                || (x.PrimaryVersion == y.PrimaryVersion && x.SecondaryVersion == y.SecondaryVersion && x.MinorVersion > y.MinorVersion);
        }

        public static bool operator <(Version x, Version y)
        {
            return x.PrimaryVersion < y.PrimaryVersion ||
               (x.PrimaryVersion == y.PrimaryVersion && x.SecondaryVersion < y.SecondaryVersion)
               || (x.PrimaryVersion == y.PrimaryVersion && x.SecondaryVersion == y.SecondaryVersion && x.MinorVersion < y.MinorVersion);
        }
    }
}
