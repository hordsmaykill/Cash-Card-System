Public Class frmMain

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
    Dim isdrnks_panmenuidden = False
    Private Const drnks_panmenu1 = 1
    Private Const drnks_panmenu2 = 2

    Dim drnks_panmenu1_contentLocation = 1
    Dim contentLocationX = 0

    Private Const drnks_panmenu_HEIGHT = 800
    Private Const drnks_panmenuL_SPEED = 175
    'end menus'


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' default states
        menuHideLoad()
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
        'drnks'

        Select Case drnks_panmenu1_contentLocation
            Case drnks_panmenu1 'panmenu1-800 '

                If isdrnks_panmenuidden Then
                    drinks_panmenu1.Location = New Point(drinks_panmenu1.Location.X + 10, drinks_panmenu1.Location.Y)
                    If drinks_panmenu1.Location.X >= 0 Then
                        drinks_panmenu1.Location = New Point(0, drinks_panmenu1.Location.Y)
                        tmrMenu.Enabled = False
                    End If
                Else
                    drinks_panmenu1.Location = New Point(drinks_panmenu1.Location.X - 23, drinks_panmenu1.Location.Y)
                    If drinks_panmenu1.Location.X <= -800 Then
                        drinks_panmenu1.Location = New Point(-800, drinks_panmenu1.Location.Y)
                        tmrMenu.Enabled = False
                    End If
                End If

            Case drnks_panmenu2 'panmenu1 0 '

                If isdrnks_panmenuidden Then
                    drinks_panmenu1.Location = New Point(drinks_panmenu1.Location.X + 10, drinks_panmenu1.Location.Y)
                    If drinks_panmenu1.Location.X >= -800 Then
                        drinks_panmenu1.Location = New Point(0, drinks_panmenu1.Location.Y)
                        tmrMenu.Enabled = False
                    End If
                Else
                    drinks_panmenu1.Location = New Point(drinks_panmenu1.Location.X - 23, drinks_panmenu1.Location.Y)
                    If drinks_panmenu1.Location.X <= 0 Then
                        drinks_panmenu1.Location = New Point(0, drinks_panmenu1.Location.Y)
                        tmrMenu.Enabled = False
                    End If
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

        For Each ctrl As Control In menu.Controls
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

    Private Sub Panel2_MouseLeave(sender As Object, e As EventArgs) Handles Panel2.MouseLeave
        Panel2.Hide()
        Panel2.BackColor = Color.FromArgb(67, 41, 6)
    End Sub

    Private Sub Panel2_MouseEnter(sender As Object, e As EventArgs) Handles Panel2.MouseEnter
        Panel2.BackColor = Color.FromArgb(111, 68, 10)

    End Sub

    Private Sub drinks_panemenubtn1_Click(sender As Object, e As EventArgs) Handles drinks_panemenubtn1.Click
        contentLocationX = drinks_panmenu1.Location.X
        isdrnks_panmenuidden = Not isdrnks_panmenuidden
        tmrContent.Enabled = True

    End Sub






































    ' end menu hide

End Class
