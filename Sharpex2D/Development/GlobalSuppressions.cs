// Copyright (c) 2012-2014 Sharpex2D - Kevin Scholz (ThuCommix)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

// Diese Datei wird von der Codeanalyse zur Wartung der SuppressMessage- 
// Attribute verwendet, die auf dieses Projekt angewendet werden.
// Unterdrückungen auf Projektebene haben entweder kein Ziel oder 
// erhalten ein spezifisches Ziel mit Namespace-, Typ-, Memberbereich usw.
//
// Wenn Sie dieser Datei eine Unterdrückung hinzufügen möchten, klicken Sie mit der rechten Maustaste auf die Meldung in den 
// Codeanalyseergebnissen, zeigen Sie auf "Meldung unterdrücken", und klicken Sie auf 
// "In Unterdrückungsdatei".
// Sie müssen dieser Datei nicht manuell Unterdrückungen hinzufügen.

using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member",
        Target =
            "Sharpex2D.Framework.Game.Game.#Sharpex2D.Framework.Game.IUpdateable.Update(Sharpex2D.Framework.Game.GameTime)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member",
        Target =
            "Sharpex2D.Framework.Game.Game.#Sharpex2D.Framework.Game.IDrawable.Render(Sharpex2D.Framework.Rendering.IRenderer,Sharpex2D.Framework.Game.GameTime)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member",
        Target = "Sharpex2D.Framework.Game.Game.#Sharpex2D.Framework.Components.IConstructable.Construct()")]