﻿//
//  ReactApplicationConfig.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2017 Roman M. Yagodin
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using YamlDotNet.Serialization;
          
namespace R7.Dnn.Extensions.React
{
    public class DnnReactConfig
    {
        [YamlMember (typeof (JavaScriptEngineConfig), Alias = "javascript-engine")]
        public JavaScriptEngineConfig JavaScriptEngine { get; set; } = new JavaScriptEngineConfig ();

        public RenderingConfig Rendering { get; set; } = new RenderingConfig ();
    }

    public class JavaScriptEngineConfig
    {
        public string EngineName { get; set; } = "JurassicJsEngine";

        public int StartEngines { get; set; } = 10;

        public int MaxEngines { get; set; } = 25;
    }

    public class RenderingConfig
    {
        public bool ForceClientOnly { get; set; }

        public bool GetEffectiveClientOnly (bool clientOnly)
        {
            // 0 || 0 => 0
            // 0 || 1 => 1
            // 1 || 0 => 1
            // 1 || 1 => 1
            return ForceClientOnly || clientOnly;
        }

        public bool GetEffectiveServerOnly (bool serverOnly)
        {
            // !1 && 1 => 0
            // !1 && 0 => 0
            // !0 && 0 => 0
            // !0 && 1 => 1
            return !ForceClientOnly && serverOnly;
        }
    }
}