﻿using DynamicPlugins.Core.DomainModel;
using DynamicPlugins.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPlugins.Core.Contracts
{
    public interface IPluginManager
    {
        List<PluginListItemViewModel> GetAllPlugins();

        void AddPlugins(PluginPackage pluginPackage);

        PluginViewModel GetPlugin(Guid pluginId);

        void EnablePlugin(Guid pluginId);

        void DisablePlugin(Guid pluginId);
    }
}
