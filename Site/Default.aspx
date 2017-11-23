<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Site._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>The Game</h1>
        <p class="lead">Cotash Is a modern Remake to the beloved retro Rogue-Like. </p>
        <p><a runat="server" href="~/" class="btn btn-primary btn-lg">Get Started &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Beginner&#39;s Guide</h2>
            <p>
                Cotash is insanely confusing. Get educted here kids.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/">Wiki &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Climb The Leaderboards</h2>
            <p style="direction: ltr">
                Cotash is a Guiness-World Record winner for the hardest game ever. Reach the leaderboards and Get Famous.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Leaderboard">Leaderboards &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Dealing With Post-Cotash Depression</h2>
            <p>
                Cotash inflicts a hard Depression on it&#39;s players, Click here instead of killing self.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/">God Bless Me &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
