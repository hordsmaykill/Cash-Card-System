﻿Imports MySql.Data.MySqlClient
Public Class frmMain
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String


    Public Sub ConnectDB()
        If Connect.State = ConnectionState.Closed Then
            str = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            Connect.ConnectionString = str
            Connect.Open()

        End If
    End Sub
    ' NAVIGATION VARS
    ' 1 Home
    ' 2 inventory
    ' 3 Menu
    ' 4 Assessment
    ' 5 Accounts


    Dim contentLocation = 1
    Dim contentLocationY = 0

    Dim isMenuHidden = False

    Private Const PAN_CONTENT_HEIGHT = 700
    Private Const PAN_SCROLL_SPEED = 175

    Private Const SIDE_MENU_HOME = 1
    Private Const SIDE_MENU_INVENTORY = 2
    Private Const SIDE_MENU_MENU = 3
    Private Const SIDE_MENU_ASSESSMENT = 4
    Private Const SIDE_MENU_ACCOUNTS = 5

    ' END NAVIGAION VARS

    'menus'
    ' try to CAPSLOCK constant variables
    Private Const DRINKS_PANMENU_WIDTH = 762
    Private Const DRINKS_SCROLL_SPEED = 127

    Private Const DRINKS_MENU1 = 1
    Private Const DRINKS_MENU2 = 2
    Private Const DRINKS_MENU3 = 3

    Dim drinksLocation = 1
    Dim drinksLocationX = 0

    'sub menus'
    Private Const SUB_PANMENU_WIDTH = 762
    Private Const SUB_SCROLL_SPEED = 127

    Private Const SUB_MENU1 = 1
    Private Const SUB_MENU2 = 2
    Private Const SUB_MENU3 = 3

    Dim SUBLocation = 1
    Dim SUBLocationX = 0
    'end sub menus'
    'main'
    Private Const MAIN_PANMENU_WIDTH = 762
    Private Const MAIN_SCROLL_SPEED = 127

    'drinks
    Private Const DRINKS_SIZEG = 0
    Private Const DRINKS_SIZEV = 1

    Private Const MAIN_MENU1 = 1
    Private Const MAIN_MENU2 = 2

    Dim MAINLocation = 1
    Dim MAINLocationX = 0


    'end menus'


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' default states
        menuHideLoad()
        Call ConnectDB()
        lblHome.BackColor = Color.FromArgb(111, 68, 10)
        picHome.BackColor = Color.FromArgb(111, 68, 10)

    End Sub

    Private Sub btnMenu_MouseEnter(sender As Object, e As EventArgs) Handles btnMenu.MouseEnter
        btnMenu.Image = My.Resources.menuHover
    End Sub

    Private Sub btnMenu_MouseLeave(sender As Object, e As EventArgs) Handles btnMenu.MouseLeave
        btnMenu.Image = My.Resources.menuDefault
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        isMenuHidden = Not isMenuHidden
        tmrMenu.Enabled = True
    End Sub

    Private Sub tmrMenu_Tick(sender As Object, e As EventArgs) Handles tmrMenu.Tick

        If isMenuHidden Then
            panWrapper.Location = New Point(panWrapper.Location.X + 10, panWrapper.Location.Y)
            If panWrapper.Location.X >= 0 Then
                panWrapper.Location = New Point(0, panWrapper.Location.Y)
                tmrMenu.Enabled = False
            End If
        Else
            panWrapper.Location = New Point(panWrapper.Location.X - 23, panWrapper.Location.Y)
            If panWrapper.Location.X <= -230 Then
                panWrapper.Location = New Point(-230, panWrapper.Location.Y)
                tmrMenu.Enabled = False
            End If
        End If

    End Sub

    Private Sub tmrContent_Tick(sender As Object, e As EventArgs) Handles tmrContent.Tick

        Select Case contentLocation
            Case SIDE_MENU_HOME ' Home 0
                If contentLocationY < 0 Then
                    panContent.Location = New Point(panContent.Location.X, panContent.Location.Y + PAN_SCROLL_SPEED)
                    If panContent.Location.Y = 0 Then
                        tmrContent.Enabled = False
                    End If
                End If

            Case SIDE_MENU_INVENTORY 'Inventory 700
                If contentLocationY > -(PAN_CONTENT_HEIGHT * 1) Then
                    panContent.Location = New Point(panContent.Location.X, panContent.Location.Y - PAN_SCROLL_SPEED)
                ElseIf contentLocationY < -(PAN_CONTENT_HEIGHT * 1) Then
                    panContent.Location = New Point(panContent.Location.X, panContent.Location.Y + PAN_SCROLL_SPEED)
                End If

                If panContent.Location.Y = -(PAN_CONTENT_HEIGHT * 1) Then
                    tmrContent.Enabled = False
                End If

            Case SIDE_MENU_MENU ' Menu 1400
                If contentLocationY > -(PAN_CONTENT_HEIGHT * 2) Then
                    panContent.Location = New Point(panContent.Location.X, panContent.Location.Y - PAN_SCROLL_SPEED)
                ElseIf contentLocationY < -(PAN_CONTENT_HEIGHT * 2) Then
                    panContent.Location = New Point(panContent.Location.X, panContent.Location.Y + PAN_SCROLL_SPEED)
                End If

                If panContent.Location.Y = -(PAN_CONTENT_HEIGHT * 2) Then
                    tmrContent.Enabled = False
                End If

            Case SIDE_MENU_ASSESSMENT 'Assessment 2800
                If contentLocationY > -(PAN_CONTENT_HEIGHT * 3) Then
                    panContent.Location = New Point(panContent.Location.X, panContent.Location.Y - PAN_SCROLL_SPEED)
                ElseIf contentLocationY < -(PAN_CONTENT_HEIGHT * 3) Then
                    panContent.Location = New Point(panContent.Location.X, panContent.Location.Y + PAN_SCROLL_SPEED)
                End If

                If panContent.Location.Y = -(PAN_CONTENT_HEIGHT * 3) Then
                    tmrContent.Enabled = False
                End If


            Case SIDE_MENU_ACCOUNTS 'Accounts 3500
                If contentLocationY > -(PAN_CONTENT_HEIGHT * 4) Then
                    panContent.Location = New Point(panContent.Location.X, panContent.Location.Y - PAN_SCROLL_SPEED)
                ElseIf contentLocationY < -(PAN_CONTENT_HEIGHT * 4) Then
                    panContent.Location = New Point(panContent.Location.X, panContent.Location.Y + PAN_SCROLL_SPEED)
                End If

                If panContent.Location.Y = -(PAN_CONTENT_HEIGHT * 4) Then
                    tmrContent.Enabled = False
                End If


        End Select

    End Sub

    Private Sub lblHome_Click(sender As Object, e As EventArgs) Handles lblHome.Click, picHome.Click
        contentLocationY = panContent.Location.Y
        contentLocation = SIDE_MENU_HOME
        tmrContent.Enabled = True
        setMenuColors()
    End Sub

    Private Sub lblInventory_Click(sender As Object, e As EventArgs) Handles lblInventory.Click, picInventory.Click
        contentLocationY = panContent.Location.Y
        contentLocation = SIDE_MENU_INVENTORY
        tmrContent.Enabled = True
        setMenuColors()
    End Sub

    Private Sub lblMenu_Click(sender As Object, e As EventArgs) Handles lblMenu.Click, picMenu.Click
        contentLocationY = panContent.Location.Y
        contentLocation = SIDE_MENU_MENU
        tmrContent.Enabled = True
        setMenuColors()
    End Sub

    Private Sub lblAssessment_Click(sender As Object, e As EventArgs) Handles lblAssessment.Click, picAssessment.Click
        contentLocationY = panContent.Location.Y
        contentLocation = SIDE_MENU_ASSESSMENT
        tmrContent.Enabled = True
        setMenuColors()
    End Sub

    Private Sub lblAccounts_Click(sender As Object, e As EventArgs) Handles lblAccounts.Click, picAccounts.Click
        contentLocationY = panContent.Location.Y
        contentLocation = SIDE_MENU_ACCOUNTS
        tmrContent.Enabled = True
        setMenuColors()
    End Sub

    Private Sub lblHome_MouseEnter(sender As Object, e As EventArgs) Handles lblHome.MouseEnter, picHome.MouseEnter
        lblHome.BackColor = Color.FromArgb(111, 68, 10)
        picHome.BackColor = Color.FromArgb(111, 68, 10)
    End Sub

    Private Sub lblHome_MouseLeave(sender As Object, e As EventArgs) Handles lblHome.MouseLeave, picHome.MouseLeave
        setMenuColors()
    End Sub

    Private Sub lblInventory_MouseEnter(sender As Object, e As EventArgs) Handles lblInventory.MouseEnter, picInventory.MouseEnter
        lblInventory.BackColor = Color.FromArgb(111, 68, 10)
        picInventory.BackColor = Color.FromArgb(111, 68, 10)
    End Sub

    Private Sub lblInventory_MouseLeave(sender As Object, e As EventArgs) Handles lblInventory.MouseLeave, picInventory.MouseLeave
        setMenuColors()
    End Sub

    Private Sub lblMenu_MouseEnter(sender As Object, e As EventArgs) Handles lblMenu.MouseEnter, picMenu.MouseEnter
        lblMenu.BackColor = Color.FromArgb(111, 68, 10)
        picMenu.BackColor = Color.FromArgb(111, 68, 10)
    End Sub

    Private Sub lblMenu_MouseLeave(sender As Object, e As EventArgs) Handles lblMenu.MouseLeave, picMenu.MouseEnter
        setMenuColors()
    End Sub

    Private Sub lblAssessment_MouseEnter(sender As Object, e As EventArgs) Handles lblAssessment.MouseEnter, picAssessment.MouseEnter
        lblAssessment.BackColor = Color.FromArgb(111, 68, 10)
        picAssessment.BackColor = Color.FromArgb(111, 68, 10)
    End Sub

    Private Sub lblAssessment_MouseLeave(sender As Object, e As EventArgs) Handles lblAssessment.MouseLeave, picAssessment.MouseLeave
        setMenuColors()
    End Sub

    Private Sub lblAccounts_MouseEnter(sender As Object, e As EventArgs) Handles lblAccounts.MouseEnter, picAccounts.MouseEnter
        lblAccounts.BackColor = Color.FromArgb(111, 68, 10)
        picAccounts.BackColor = Color.FromArgb(111, 68, 10)

    End Sub

    Private Sub lblAccounts_MouseLeave(sender As Object, e As EventArgs) Handles lblAccounts.MouseLeave, picAccounts.MouseLeave
        setMenuColors()
    End Sub


    Private Sub setMenuColors()
        lblHome.BackColor = Color.FromArgb(67, 41, 6)
        picHome.BackColor = Color.FromArgb(67, 41, 6)

        lblInventory.BackColor = Color.FromArgb(67, 41, 6)
        picInventory.BackColor = Color.FromArgb(67, 41, 6)

        lblMenu.BackColor = Color.FromArgb(67, 41, 6)
        picMenu.BackColor = Color.FromArgb(67, 41, 6)

        lblAssessment.BackColor = Color.FromArgb(67, 41, 6)
        picAssessment.BackColor = Color.FromArgb(67, 41, 6)

        lblAccounts.BackColor = Color.FromArgb(67, 41, 6)
        picAccounts.BackColor = Color.FromArgb(67, 41, 6)

        Select Case contentLocation
            Case SIDE_MENU_HOME
                lblHome.BackColor = Color.FromArgb(111, 68, 10)
                picHome.BackColor = Color.FromArgb(111, 68, 10)

            Case SIDE_MENU_INVENTORY
                lblInventory.BackColor = Color.FromArgb(111, 68, 10)
                picInventory.BackColor = Color.FromArgb(111, 68, 10)

            Case SIDE_MENU_MENU
                lblMenu.BackColor = Color.FromArgb(111, 68, 10)
                picMenu.BackColor = Color.FromArgb(111, 68, 10)

            Case SIDE_MENU_ASSESSMENT
                lblAssessment.BackColor = Color.FromArgb(111, 68, 10)
                picAssessment.BackColor = Color.FromArgb(111, 68, 10)

            Case SIDE_MENU_ACCOUNTS
                lblAccounts.BackColor = Color.FromArgb(111, 68, 10)
                picAccounts.BackColor = Color.FromArgb(111, 68, 10)
        End Select


    End Sub

    ' menu hide when click on content
    Private Sub menuHideLoad()
        For Each ctrl As Control In panContent.Controls
            AddHandler ctrl.Click, AddressOf ctrl_Click
        Next

        For Each ctrl As Control In panHome.Controls
            AddHandler ctrl.Click, AddressOf ctrl_Click
        Next

        For Each ctrl As Control In panInventory.Controls
            AddHandler ctrl.Click, AddressOf ctrl_Click
        Next

        For Each ctrl As Control In panmenumenu.Controls
            AddHandler ctrl.Click, AddressOf ctrl_Click
        Next

        For Each ctrl As Control In panAssessment.Controls
            AddHandler ctrl.Click, AddressOf ctrl_Click
        Next

    End Sub

    Private Sub menuHide() Handles panContent.Click, panHeading.Click
        ctrl_Click(Me, New EventArgs)
    End Sub

    Private Sub ctrl_Click(sender As Object, e As EventArgs)
        If isMenuHidden Then
            isMenuHidden = False
            tmrMenu.Enabled = True
        End If
    End Sub

    Private Sub tDateTime_Tick(sender As Object, e As EventArgs) Handles tDateTime.Tick
        ltime.Text = DateTime.Now.ToLongTimeString
        lDate.Text = DateTime.Today.ToLongDateString
    End Sub

    'logoutbutton'

    Private Sub piclogout2_MouseEnter(sender As Object, e As EventArgs) Handles piclogout2.MouseEnter
        Panel2.Show()
    End Sub

    Private Sub Panel2_MouseLeave(sender As Object, e As EventArgs) Handles Panel2.MouseLeave, picLogout.Leave
        Panel2.Hide()
        Panel2.BackColor = Color.FromArgb(67, 41, 6)
    End Sub

    Private Sub Panel2_MouseEnter(sender As Object, e As EventArgs) Handles Panel2.MouseEnter
        Panel2.BackColor = Color.FromArgb(111, 68, 10)

    End Sub
    'DRNKS BTN'
    Private Sub drinks_panemenubtn1_Click(sender As Object, e As EventArgs) Handles drinks_panemenubtn1.Click
        drinksLocationX = drinks_panmenu1.Location.X
        drinksLocation = DRINKS_MENU1
        tmrDrinks1.Enabled = True
    End Sub

    Private Sub drinks_panemenubtn2_Click(sender As Object, e As EventArgs) Handles drinks_panemenubtn2.Click
        drinksLocationX = drinks_panmenu1.Location.X
        drinksLocation = DRINKS_MENU2
        tmrDrinks1.Enabled = True
    End Sub

    Private Sub drinks_panemenubtn3_Click(sender As Object, e As EventArgs) Handles drinks_panemenubtn3.Click
        drinksLocationX = drinks_panmenu1.Location.X
        drinksLocation = DRINKS_MENU3
        tmrDrinks1.Enabled = True
    End Sub
    'END DNKS'
    Private Sub main_panemenubtn1_Click(sender As Object, e As EventArgs) Handles main_panemenubtn1.Click
        MAINLocationX = main_panmenu1.Location.X
        MAINLocation = MAIN_MENU1
        tmrMain2.Enabled = True


    End Sub

    Private Sub main_panemenubtn2_Click(sender As Object, e As EventArgs) Handles main_panemenubtn2.Click
        MAINLocationX = main_panmenu1.Location.X
        MAINLocation = MAIN_MENU2
        tmrMain2.Enabled = True
    End Sub




    Private Sub tmrDrinks1_Tick(sender As Object, e As EventArgs) Handles tmrDrinks1.Tick

        Select Case drinksLocation
            Case DRINKS_MENU1 ' btn 1
                If drinksLocationX < 0 Then
                    drinks_panmenu1.Location = New Point(drinks_panmenu1.Location.X + DRINKS_SCROLL_SPEED, drinks_panmenu1.Location.Y)
                    If drinks_panmenu1.Location.X = 0 Then
                        tmrDrinks1.Enabled = False
                    End If
                End If


            Case DRINKS_MENU2 'btn 2
                If drinksLocationX = 0 Then
                    drinks_panmenu1.Location = New Point(drinks_panmenu1.Location.X - DRINKS_SCROLL_SPEED, drinks_panmenu1.Location.Y)

                    If drinks_panmenu1.Location.X = -DRINKS_PANMENU_WIDTH Then
                        tmrDrinks1.Enabled = False
                    End If

                ElseIf drinksLocationX = -(MAIN_PANMENU_WIDTH * 2)
                    drinks_panmenu1.Location = New Point(drinks_panmenu1.Location.X + DRINKS_SCROLL_SPEED, drinks_panmenu1.Location.Y)

                    If drinks_panmenu1.Location.X = -DRINKS_PANMENU_WIDTH Then
                        tmrDrinks1.Enabled = False
                    End If
                End If



            Case DRINKS_MENU3 ' btn 3
                If drinksLocationX > -(DRINKS_PANMENU_WIDTH * 2) Then
                    drinks_panmenu1.Location = New Point(drinks_panmenu1.Location.X - DRINKS_SCROLL_SPEED, drinks_panmenu1.Location.Y)
                    If drinks_panmenu1.Location.X = -(DRINKS_PANMENU_WIDTH * 2) Then
                        tmrDrinks1.Enabled = False
                    End If
                End If

        End Select

    End Sub

    Private Sub tmrMain2_Tick(sender As Object, e As EventArgs) Handles tmrMain2.Tick

        Select Case MAINLocation
            Case MAIN_MENU1 ' btn 1
                If MAINLocationX = -MAIN_PANMENU_WIDTH Then
                    main_panmenu1.Location = New Point(main_panmenu1.Location.X + MAIN_SCROLL_SPEED, main_panmenu1.Location.Y)
                    If main_panmenu1.Location.X = 0 Then
                        tmrMain2.Enabled = False
                    End If
                End If

            Case MAIN_MENU2 'btn 2
                If MAINLocationX = 0 Then
                    main_panmenu1.Location = New Point(main_panmenu1.Location.X - MAIN_SCROLL_SPEED, main_panmenu1.Location.Y)
                    If main_panmenu1.Location.X = -MAIN_PANMENU_WIDTH Then
                        tmrMain2.Enabled = False
                    End If
                End If

        End Select
    End Sub

    Private Sub tmrSubmenu_Tick(sender As Object, e As EventArgs) Handles tmrSubmenu.Tick
        Select Case SUBLocation
            Case SUB_MENU1 ' btn 1
                If SUBLocationX = -SUB_PANMENU_WIDTH Then
                    sub_panmenu1.Location = New Point(sub_panmenu1.Location.X + SUB_SCROLL_SPEED, sub_panmenu1.Location.Y)
                    If sub_panmenu1.Location.X = 0 Then
                        tmrSubmenu.Enabled = False
                    End If
                End If

            Case SUB_MENU2 'btn 2
                If SUBLocationX = 0 Then
                    sub_panmenu1.Location = New Point(sub_panmenu1.Location.X - SUB_SCROLL_SPEED, sub_panmenu1.Location.Y)
                    If sub_panmenu1.Location.X = -SUB_PANMENU_WIDTH Then
                        tmrSubmenu.Enabled = False
                    End If
                End If

        End Select
    End Sub




    Private Sub panHome_MouseEnter(sender As Object, e As EventArgs) Handles panHome.MouseEnter
        Panel2.Hide()
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick, picLogout.Click
        Dim reply As MsgBoxResult

        reply = MsgBox("Do you really want to exit?", MsgBoxStyle.YesNo, "Exit")
        If reply = MsgBoxResult.Yes Then
            End
        End If
    End Sub

    Private Sub submenu_panmenu1_Click(sender As Object, e As EventArgs) Handles submenu_panmenu1.Click
        SUBLocationX = sub_panmenu1.Location.X
        SUBLocation = SUB_MENU1
        tmrSubmenu.Enabled = True
    End Sub

    Private Sub submenu_panbtn2_Click(sender As Object, e As EventArgs) Handles submenu_panbtn2.Click
        SUBLocationX = sub_panmenu1.Location.X
        SUBLocation = SUB_MENU2
        tmrSubmenu.Enabled = True
    End Sub

    ' method for adding row to dgv
    ' params : 
    '   prodCode - product code
    '   size - value must be either DRINKS_SIZEG or DRINKS_SIZEV
    Private Sub drinksToDGV(prodCode As String, size As Integer)

        Dim sqlQuery As String = ""
        Select Case size
            Case DRINKS_SIZEG
                sqlQuery = "SELECT prod_code, prod_name, prod_priceG, prod_class FROM tblproducts WHERE 
            prod_code ='"

            Case DRINKS_SIZEV
                sqlQuery = "SELECT prod_code, prod_name, prod_priceV, prod_class FROM tblproducts WHERE 
            prod_code ='"
        End Select
        sqlQuery = sqlQuery & prodCode & "'"


        With Command
            .Connection = Connect
            .CommandText = sqlQuery
        End With
        Reader = Command.ExecuteReader
        Reader.Read()

        Dim column As Integer = dgvorders.ColumnCount
        Dim row As Integer = dgvorders.RowCount

        dgvorders.Rows.Add()
        For i As Integer = 0 To column - 1
            dgvorders.Item(i, row).Value = Reader.Item(i)
        Next
        Reader.Close()
    End Sub

    Private Sub menu_d_ms_G_Click(sender As Object, e As EventArgs) Handles menu_d_ms_G.Click
        'melon swirl'
        drinksToDGV("D_MS", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_ms_V_Click(sender As Object, e As EventArgs) Handles menu_d_ms_V.Click
        drinksToDGV("D_MS", DRINKS_SIZEV)
    End Sub
    'choco loco'
    Private Sub menu_d_cl_G_Click(sender As Object, e As EventArgs) Handles menu_d_cl_G.Click
        drinksToDGV("D_CL", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_cl_V_Click(sender As Object, e As EventArgs) Handles menu_d_cl_V.Click
        drinksToDGV("D_CL", DRINKS_SIZEV)
    End Sub
    'purple brew'
    Private Sub menu_d_pb_G_Click(sender As Object, e As EventArgs) Handles menu_d_pb_G.Click
        drinksToDGV("D_PB", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_pb_V_Click(sender As Object, e As EventArgs) Handles menu_d_pb_V.Click
        drinksToDGV("D_PB", DRINKS_SIZEV)
    End Sub
    'Strawberry blush' 
    Private Sub menu_d_sb_G_Click(sender As Object, e As EventArgs) Handles menu_d_sb_G.Click
        drinksToDGV("D_SB", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_sb_V_Click(sender As Object, e As EventArgs) Handles menu_d_sb_V.Click
        drinksToDGV("D_SB", DRINKS_SIZEV)
    End Sub
    'peachy keech'
    Private Sub menu_d_pk_G_Click(sender As Object, e As EventArgs) Handles menu_d_pk_G.Click
        drinksToDGV("D_PK", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_pk_V_Click(sender As Object, e As EventArgs) Handles menu_d_pk_V.Click
        drinksToDGV("D_PK", DRINKS_SIZEV)
    End Sub
    'trophical Mango'
    Private Sub menu_d_tm_G_Click(sender As Object, e As EventArgs) Handles menu_d_tm_G.Click
        drinksToDGV("D_TM", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_tm_V_Click(sender As Object, e As EventArgs) Handles menu_d_tm_V.Click
        drinksToDGV("D_TM", DRINKS_SIZEG)
    End Sub
    'vanilla cloud'
    Private Sub menu_d_vc_G_Click(sender As Object, e As EventArgs) Handles menu_d_vc_G.Click
        drinksToDGV("D_VC", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_vc_V_Click(sender As Object, e As EventArgs) Handles menu_d_vc_V.Click
        drinksToDGV("D_VC", DRINKS_SIZEV)
    End Sub
    'taro treat'
    Private Sub menu_d_tt_G_Click(sender As Object, e As EventArgs) Handles menu_d_tt_G.Click
        drinksToDGV("D_TT", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_tt_V_Click(sender As Object, e As EventArgs) Handles menu_d_tt_V.Click
        drinksToDGV("D_TT", DRINKS_SIZEV)
    End Sub
    'Zesty dew'
    Private Sub menu_d_zd_G_Click(sender As Object, e As EventArgs) Handles menu_d_zd_G.Click
        drinksToDGV("D_ZD", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_zd_V_Click(sender As Object, e As EventArgs) Handles menu_d_zd_V.Click
        drinksToDGV("D_ZD", DRINKS_SIZEV)
    End Sub
    'Winter Choco'
    Private Sub menu_d_wc_G_Click(sender As Object, e As EventArgs) Handles menu_d_wc_G.Click
        drinksToDGV("D_WC", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_wc_V_Click(sender As Object, e As EventArgs) Handles menu_d_wc_V.Click
        drinksToDGV("D_WC", DRINKS_SIZEV)
    End Sub
    'oreo wacko'
    Private Sub menu_d_oc_G_Click(sender As Object, e As EventArgs) Handles menu_d_ow_G.Click
        drinksToDGV("D_OW", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_ow_V_Click(sender As Object, e As EventArgs) Handles menu_d_ow_V.Click
        drinksToDGV("D_OW", DRINKS_SIZEV)
    End Sub
    'Green Apple Tea'
    Private Sub menu_d_gat_G_Click(sender As Object, e As EventArgs) Handles menu_d_gat_G.Click
        drinksToDGV("D_GAT", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_gat_V_Click(sender As Object, e As EventArgs) Handles menu_d_gat_V.Click
        drinksToDGV("D_GAT", DRINKS_SIZEV)
    End Sub
    'Blue berry Tea'
    Private Sub menu_d_bbt_G_Click(sender As Object, e As EventArgs) Handles menu_d_bbt_G.Click
        drinksToDGV("D_BBT", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_bbt_V_Click(sender As Object, e As EventArgs) Handles menu_d_bbt_V.Click
        drinksToDGV("D_BBT", DRINKS_SIZEV)
    End Sub
    'Strawberry TEa'
    Private Sub menu_d_sbt_G_Click(sender As Object, e As EventArgs) Handles menu_d_sbt_G.Click
        drinksToDGV("D_ST", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_sbt_V_Click(sender As Object, e As EventArgs) Handles menu_d_sbt_V.Click
        drinksToDGV("D_ST", DRINKS_SIZEV)
    End Sub
    ' Kiwi Tea'
    Private Sub menu_d_kt_G_Click(sender As Object, e As EventArgs) Handles menu_d_kt_G.Click
        drinksToDGV("D_KT", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_kt_V_Click(sender As Object, e As EventArgs) Handles menu_d_kt_V.Click
        drinksToDGV("D_KT", DRINKS_SIZEV)
    End Sub
    'Mango Tea'
    Private Sub menu_d_mt_G_Click(sender As Object, e As EventArgs) Handles menu_d_mt_G.Click
        drinksToDGV("D_MT", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_mt_V_Click(sender As Object, e As EventArgs) Handles menu_d_mt_V.Click
        drinksToDGV("D_MT", DRINKS_SIZEV)
    End Sub

    Private Sub menu_d_pt_G_Click(sender As Object, e As EventArgs) Handles menu_d_pt_G.Click
        drinksToDGV("D_PT", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_pt_V_Click(sender As Object, e As EventArgs) Handles menu_d_pt_V.Click
        drinksToDGV("D_PT", DRINKS_SIZEV)
    End Sub
    'Lychee Tea'
    Private Sub menu_d_lt_G_Click(sender As Object, e As EventArgs) Handles menu_d_lt_G.Click
        drinksToDGV("D_LT", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_lt_V_Click(sender As Object, e As EventArgs) Handles menu_d_lt_V.Click
        drinksToDGV("D_LT", DRINKS_SIZEV)
    End Sub
    'Lemon Tea'
    Private Sub menu_d_lemont_G_Click(sender As Object, e As EventArgs) Handles menu_d_lemont_G.Click
        drinksToDGV("D_Lemo", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_lemont_V_Click(sender As Object, e As EventArgs) Handles menu_d_lemont_V.Click
        drinksToDGV("D_Lemo", DRINKS_SIZEV)
    End Sub
    'Winter Melon'
    Private Sub menu_d_wm_G_Click(sender As Object, e As EventArgs) Handles menu_d_wm_G.Click
        drinksToDGV("D_WM", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_wm_V_Click(sender As Object, e As EventArgs) Handles menu_d_wm_V.Click
        drinksToDGV("D_WM", DRINKS_SIZEV)
    End Sub

    Private Sub menu_d_pmk_G_Click(sender As Object, e As EventArgs) Handles menu_d_pmk_G.Click
        drinksToDGV("D_PMK", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_pmk_V_Click(sender As Object, e As EventArgs) Handles menu_d_pmk_V.Click
        drinksToDGV("D_PMK", DRINKS_SIZEV)
    End Sub

    Private Sub menu_d_smk_G_Click(sender As Object, e As EventArgs) Handles menu_d_smk_G.Click
        drinksToDGV("D_SMT", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_smk_V_Click(sender As Object, e As EventArgs) Handles menu_d_smk_V.Click
        drinksToDGV("D_SMT", DRINKS_SIZEV)
    End Sub

    Private Sub menu_d_bmk_G_Click(sender As Object, e As EventArgs) Handles menu_d_bmk_G.Click
        drinksToDGV("D_BMT", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_bmk_V_Click(sender As Object, e As EventArgs) Handles menu_d_bmk_V.Click
        drinksToDGV("D_BMT", DRINKS_SIZEV)
    End Sub

    Private Sub menu_d_mmk_G_Click(sender As Object, e As EventArgs) Handles menu_d_mmt_G.Click
        drinksToDGV("D_MMT", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_mmk_V_Click(sender As Object, e As EventArgs) Handles menu_d_mmt_V.Click
        drinksToDGV("D_MMT", DRINKS_SIZEV)
    End Sub

    Private Sub menu_d_hmt_G_Click(sender As Object, e As EventArgs) Handles menu_d_hmt_G.Click
        drinksToDGV("D_HMT", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_hmt_V_Click(sender As Object, e As EventArgs) Handles menu_d_hmt_V.Click
        drinksToDGV("D_HMT", DRINKS_SIZEV)
    End Sub

    Private Sub menu_d_cm_G_Click(sender As Object, e As EventArgs) Handles menu_d_cm_G.Click
        drinksToDGV("D_CK", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_cm_V_Click(sender As Object, e As EventArgs) Handles menu_d_cm_V.Click
        drinksToDGV("D_CK", DRINKS_SIZEV)
    End Sub

    Private Sub menu_d_ss_G_Click(sender As Object, e As EventArgs) Handles menu_d_ss_G.Click
        drinksToDGV("D_SS", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_ss_V_Click(sender As Object, e As EventArgs) Handles menu_d_ss_V.Click
        drinksToDGV("D_SS", DRINKS_SIZEV)
    End Sub

    Private Sub menu_d_ll_G_Click(sender As Object, e As EventArgs) Handles menu_d_ll_G.Click
        drinksToDGV("D_LL", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_ll_V_Click(sender As Object, e As EventArgs) Handles menu_d_ll_V.Click
        drinksToDGV("D_LL", DRINKS_SIZEV)
    End Sub

    Private Sub menu_d_dp_G_Click(sender As Object, e As EventArgs) Handles menu_d_dp_G.Click
        drinksToDGV("D_DP", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_dp_V_Click(sender As Object, e As EventArgs) Handles menu_d_dp_V.Click
        drinksToDGV("D_DP", DRINKS_SIZEV)
    End Sub

    Private Sub menu_d_mm_G_Click(sender As Object, e As EventArgs) Handles menu_d_mm_G.Click
        drinksToDGV("D_MM", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_mm_V_Click(sender As Object, e As EventArgs) Handles menu_d_mm_V.Click
        drinksToDGV("D_MM", DRINKS_SIZEV)
    End Sub
End Class
