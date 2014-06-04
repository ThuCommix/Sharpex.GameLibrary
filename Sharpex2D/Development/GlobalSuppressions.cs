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
            "Sharpex2D.Framework.Game.Game.#Sharpex2D.Framework.Game.IUpdateable.Tick(Sharpex2D.Framework.Game.GameTime)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member",
        Target =
            "Sharpex2D.Framework.Game.Game.#Sharpex2D.Framework.Game.IDrawable.Render(Sharpex2D.Framework.Rendering.IRenderer,Sharpex2D.Framework.Game.GameTime)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member",
        Target = "Sharpex2D.Framework.Game.Game.#Sharpex2D.Framework.Components.IConstructable.Construct()")]