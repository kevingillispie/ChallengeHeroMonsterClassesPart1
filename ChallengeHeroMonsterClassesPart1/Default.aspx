<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeHeroMonsterClassesPart1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            VISUAL STUDIO BATTLE ROYALE<br />
            <br />
            Press the FIGHT button to pit our iron-jawed hero, Manducate, against the insatiable beast, Bolus!<br />
            <br />
            <asp:Button ID="fightButton" runat="server" OnClick="fightButton_Click" Text="FIGHT!" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <asp:Label ID="resultLabel2" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
