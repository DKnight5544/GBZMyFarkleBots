<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fizban.aspx.cs" Inherits="MyFarkleBots.Fizban" %>

<html id="HtmlObject">
<head>
    <meta charset="utf-8" />
    <title>Fizban</title>
</head>
<body style="padding: 0;margin:0;">
    <style>
        p{font-family: sans-serif;margin-bottom:0}        
    </style>
    <div style="
        background-image: url(images/Paladine.jpg);
        background-repeat: no-repeat;
        background-size: contain;
        background-position: top left; 
        background-color:white;
        width: 100%; 
        max-width: 390px; 
        height: 155px;
        padding:5px;
        ">
        <div style="
            font-family: sans-serif;
            text-align:left;
            background-color:transparent;
            width:245px;
            margin-top:10px;
            margin-right:5px;
            float:right;
            ">
            <p style="color: black;font-size:26px;margin-top:0;">Fizban</p>
            <p style="color: gray;font-size:12px;margin-top:0;">Programmer: David W. Knight</p>
            <p style="color: gray;font-size:12px;margin-top:3px;">Tech Used: asp.net, c#</p>
            <p style="color: gray;font-size:12px;margin-top:6px;"><b>Strategy:</b> Keeps ones and fives. Rolls again if 3 or more dice remain.</p>
            <p><a href="http://gbz.azurewebsites.net/Farkle/PlayFarkle.aspx?api=http://dwkbots.azurewebsites.net/fizban.aspx" 
                  target ="_blank" 
                  style="color:gray;font-size:12px;margin-top:6px;"><b>Play Farkle!</b></a></p>
        </div>
    </div>
</body>
</html>