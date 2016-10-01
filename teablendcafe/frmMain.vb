Imports MySql.Data.MySqlClient
Public Class frmMain
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Public qtyRetrieved As Integer
    Dim SelectedAdmin As String
    Dim SelectedMember As String



    Public Sub ConnectDB()
        If Connect.State = ConnectionState.Closed Then
            str = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            Connect.ConnectionString = str
            Connect.Open()

            qtyRetrieved = 0

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
    Private Const DRINKS_PANMENU_WIDTH = 762
    Private Const DRINKS_SCROLL_SPEED = 127

    Private Const DRINKS_MENU1 = 1
    Private Const DRINKS_MENU2 = 2
    Private Const DRINKS_MENU3 = 3

    Dim drinksLocation = 1
    Dim drinksLocationX = 0

    ' Sub Menus
    Private Const SUB_PANMENU_WIDTH = 762
    Private Const SUB_SCROLL_SPEED = 127

    Private Const SUB_MENU1 = 1
    Private Const SUB_MENU2 = 2
    Private Const SUB_MENU3 = 3

    Dim SUBLocation = 1
    Dim SUBLocationX = 0

    'main'
    Private Const MAIN_PANMENU_WIDTH = 762
    Private Const MAIN_SCROLL_SPEED = 127

    Private Const MAIN_MENU1 = 1
    Private Const MAIN_MENU2 = 2

    Dim MAINLocation = 1
    Dim MAINLocationX = 0

    Private Const DRINKS_SIZEG = 0
    Private Const DRINKS_SIZEV = 1


    ' accounts vars
    Public currentUser As String
    Public userSelected As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' default states
        menuHideLoad()
        Call ConnectDB()
        Call AccountsDGV()
        Call ChangePass()
        Call DGVINV()
        membersDGV()

        lblHome.BackColor = Color.FromArgb(111, 68, 10)
        picHome.BackColor = Color.FromArgb(111, 68, 10)
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

    'datagrid'
    Public Sub AccountsDGV()
        accounts_dgv.Rows.Clear()

        With Command
            .Connection = Connect
            .CommandText = "SELECT * FROM tbladministrators"
        End With
        Reader = Command.ExecuteReader

        If Reader.HasRows Then
            While Reader.Read
                accounts_dgv.Rows.Add(Reader.Item(0), Reader.Item(2))
            End While
        End If
        Reader.Close()

    End Sub
    'members dgv'
    Public Sub membersDGV()
        dgv_members.Rows.Clear()

        With Command
            .Connection = Connect
            .CommandText = "SELECT * FROM tblcustomers"
        End With
        Reader = Command.ExecuteReader

        If Reader.HasRows Then
            While Reader.Read
                dgv_members.Rows.Add(Reader.Item(0), Reader.Item(1), Reader.Item(2), Reader.Item(3))
            End While
        End If
        Reader.Close()

    End Sub

    Private Sub drinksToDGV(prodCode As String, size As Integer)

        ' get qty
        frmquantity.prodCode = prodCode
        frmquantity.ShowDialog()

        ' exit if cancel
        If qtyRetrieved = -1 Then
            Exit Sub
        End If

        Dim sql As String = "SELECT prod_code, prod_name, prod_priceG, prod_priceV FROM tblproducts WHERE 
            prod_code ='" & prodCode & "'"

        With Command
            .Connection = Connect
            .CommandText = sql
        End With
        Reader = Command.ExecuteReader
        Reader.Read()

        If Not Reader.HasRows Then
            MsgBox("An error has occurred.")
            Exit Sub
        End If

        Dim column As Integer = dgvorders.ColumnCount
        Dim row As Integer = dgvorders.RowCount

        ' get prices
        Dim priceG = Reader.Item(2)
        Dim priceV = Reader.Item(3)

        ' if it's a dish don't concat size
        Dim curProdName As String = ""


        ' update product name concat size
        Select Case size
            Case DRINKS_SIZEG
                If Not IsDBNull(priceV) Then
                    curProdName = Reader.Item(1) & " Grande"
                Else
                    curProdName = Reader.Item(1)
                End If
            Case DRINKS_SIZEV
                curProdName = Reader.Item(1) & " Venti"
        End Select


        ' check if prod is already at the dgv
        For i As Integer = 0 To row - 1
            Dim selProdName As String ' selected from dgv
            selProdName = dgvorders.Item(1, i).Value

            If curProdName = selProdName Then
                ' overwrite the qty
                dgvorders.Item(2, i).Value = qtyRetrieved
                Reader.Close()

                ' update total
                Dim qtyUpdate As Integer = dgvorders.Item(2, i).Value
                Dim priceUpdate As Double = dgvorders.Item(3, i).Value
                dgvorders.Item(4, i).Value = (qtyUpdate * priceUpdate)
                updateTotalOrders()
                Exit Sub
            End If
        Next

        ' create new row
        dgvorders.Rows.Add()
        ' prod code
        dgvorders.Item(0, row).Value = Reader.Item(0)

        ' prod name
        dgvorders.Item(1, row).Value = curProdName

        ' quantity
        dgvorders.Item(2, row).Value = qtyRetrieved

        ' price
        Select Case size
            Case DRINKS_SIZEG
                dgvorders.Item(3, row).Value = priceG
            Case DRINKS_SIZEV
                dgvorders.Item(3, row).Value = priceV
        End Select

        ' total
        Dim qty As Integer = dgvorders.Item(2, row).Value
        Dim price As Double = dgvorders.Item(3, row).Value
        dgvorders.Item(4, row).Value = (qty * price)

        ' reset qty
        qtyRetrieved = 1

        ' update total
        updateTotalOrders()


        Reader.Close()
    End Sub

    Private Sub updateTotalOrders()
        If dgvorders.RowCount > 0 Then
            ' add and update total
            Dim total As Double = 0
            For i As Integer = 0 To dgvorders.RowCount - 1
                total += dgvorders.Item(4, i).Value
            Next
            txtTotalOrder.Text = FormatNumber(total)
            btnDeleteOrders.Enabled = True
            btnclearorder.Enabled = True
            btnOrder.Enabled = True
        Else
            txtTotalOrder.Text = "0"
            btnDeleteOrders.Enabled = False
            btnclearorder.Enabled = True
            btnOrder.Enabled = True
        End If
    End Sub

    ' MENU COLOR STATES
    ' color states for menu main form
    Private Sub drinksSelectedPage(selected As Integer)
        ' reset all colors
        drinks_panemenubtn1.BackColor = Color.FromArgb(67, 41, 6)
        drinks_panemenubtn2.BackColor = Color.FromArgb(67, 41, 6)
        drinks_panemenubtn3.BackColor = Color.FromArgb(67, 41, 6)

        ' set selected color
        Select Case selected
            Case 1
                drinks_panemenubtn1.BackColor = Color.FromArgb(111, 68, 10)
            Case 2
                drinks_panemenubtn2.BackColor = Color.FromArgb(111, 68, 10)
            Case 3
                drinks_panemenubtn3.BackColor = Color.FromArgb(111, 68, 10)
        End Select
    End Sub

    Private Sub foodSelectedPage1(selected As Integer)
        submenu_panmenu1.BackColor = Color.FromArgb(67, 41, 6)
        submenu_panbtn2.BackColor = Color.FromArgb(67, 41, 6)

        Select Case selected
            Case 1
                submenu_panmenu1.BackColor = Color.FromArgb(111, 68, 10)
            Case 2
                submenu_panbtn2.BackColor = Color.FromArgb(111, 68, 10)
        End Select
    End Sub

    Private Sub foodSelectedPage2(selected As Integer)
        main_panemenubtn1.BackColor = Color.FromArgb(67, 41, 6)
        main_panemenubtn2.BackColor = Color.FromArgb(67, 41, 6)

        Select Case selected
            Case 1
                main_panemenubtn1.BackColor = Color.FromArgb(111, 68, 10)
            Case 2
                main_panemenubtn2.BackColor = Color.FromArgb(111, 68, 10)
        End Select

    End Sub
    ' END MENU COLOR STATES

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
    Dim isLogoutShown As Boolean = False
    Private Sub piclogout2_Click(sender As Object, e As EventArgs) Handles piclogout2.Click
        If isLogoutShown Then
            panLogout.Hide()
            piclogout2.Image = My.Resources.arrowdown
            panLogout.BackColor = Color.FromArgb(67, 41, 6)
            isLogoutShown = False
        Else
            panLogout.Show()
            piclogout2.Image = My.Resources.arrowleft
            isLogoutShown = True
        End If

    End Sub

    Private Sub Panel2_MouseEnter(sender As Object, e As EventArgs) Handles panLogout.MouseEnter, picLogout.MouseEnter
        panLogout.BackColor = Color.FromArgb(111, 68, 10)

    End Sub

    Private Sub panLogout_MouseLeave(sender As Object, e As EventArgs) Handles panLogout.MouseLeave, picLogout.MouseLeave
        panLogout.BackColor = Color.FromArgb(67, 41, 6)
    End Sub

    Private Sub picLogout_Click(sender As Object, e As EventArgs) Handles picLogout.Click, panLogout.Click, lbllogout.Click
        Dim reply As MsgBoxResult

        reply = MsgBox("Do you really want to exit?", MsgBoxStyle.YesNo, "Exit")
        If reply = MsgBoxResult.Yes Then
            Dim command As New MySqlCommand
            With command
                .Connection = Connect
                .CommandText = "INSERT INTO tbltimeintimeout(user, description) VALUES('" & currentUser & "', 'out')"
                .ExecuteNonQuery()
            End With
            Me.Close()
            login.Show()
        End If
    End Sub


    'DRNKS BTN'
    Private Sub drinks_panemenubtn1_Click(sender As Object, e As EventArgs) Handles drinks_panemenubtn1.Click
        drinksLocationX = drinks_panmenu1.Location.X
        drinksLocation = DRINKS_MENU1
        tmrDrinks1.Enabled = True

        drinksSelectedPage(1)
    End Sub

    Private Sub drinks_panemenubtn2_Click(sender As Object, e As EventArgs) Handles drinks_panemenubtn2.Click
        drinksLocationX = drinks_panmenu1.Location.X
        drinksLocation = DRINKS_MENU2
        tmrDrinks1.Enabled = True

        drinksSelectedPage(2)
    End Sub

    Private Sub drinks_panemenubtn3_Click(sender As Object, e As EventArgs) Handles drinks_panemenubtn3.Click
        drinksLocationX = drinks_panmenu1.Location.X
        drinksLocation = DRINKS_MENU3
        tmrDrinks1.Enabled = True

        drinksSelectedPage(3)
    End Sub
    'END DNKS'
    Private Sub main_panemenubtn1_Click(sender As Object, e As EventArgs) Handles main_panemenubtn1.Click
        MAINLocationX = main_panmenu1.Location.X
        MAINLocation = MAIN_MENU1
        tmrMain2.Enabled = True

        foodSelectedPage2(1)
    End Sub

    Private Sub main_panemenubtn2_Click(sender As Object, e As EventArgs) Handles main_panemenubtn2.Click
        MAINLocationX = main_panmenu1.Location.X
        MAINLocation = MAIN_MENU2
        tmrMain2.Enabled = True

        foodSelectedPage2(2)
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
        panLogout.Hide()
    End Sub

    Private Sub submenu_panmenu1_Click(sender As Object, e As EventArgs) Handles submenu_panmenu1.Click
        SUBLocationX = sub_panmenu1.Location.X
        SUBLocation = SUB_MENU1
        tmrSubmenu.Enabled = True

        foodSelectedPage1(1)
    End Sub

    Private Sub submenu_panbtn2_Click(sender As Object, e As EventArgs) Handles submenu_panbtn2.Click
        SUBLocationX = sub_panmenu1.Location.X
        SUBLocation = SUB_MENU2
        tmrSubmenu.Enabled = True

        foodSelectedPage1(2)
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
        drinksToDGV("D_TM", DRINKS_SIZEV)
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
        drinksToDGV("D_LL", DRINKS_SIZEV)
    End Sub

    Private Sub menu_d_mm_G_Click(sender As Object, e As EventArgs) Handles menu_d_mm_G.Click
        drinksToDGV("D_MM", DRINKS_SIZEG)
    End Sub

    Private Sub menu_d_mm_V_Click(sender As Object, e As EventArgs) Handles menu_d_mm_V.Click
        drinksToDGV("D_MM", DRINKS_SIZEV)
    End Sub

    Private Sub menu_btn_c_Click(sender As Object, e As EventArgs) Handles menu_btn_c.Click
        drinksToDGV("DSH_C", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_cbf_Click(sender As Object, e As EventArgs) Handles menu_btn_cbf.Click
        drinksToDGV("DSH_CB", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_ss_Click(sender As Object, e As EventArgs) Handles menu_btn_ss.Click
        drinksToDGV("DSH_SS", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_te_Click(sender As Object, e As EventArgs) Handles menu_btn_te.Click
        drinksToDGV("DSH_TE", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_fbw_Click(sender As Object, e As EventArgs) Handles menu_btn_fbw.Click
        drinksToDGV("DSH_FB", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_n_Click(sender As Object, e As EventArgs) Handles menu_btn_n.Click
        drinksToDGV("DSH_N", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_sbs_Click(sender As Object, e As EventArgs) Handles menu_btn_sbs.Click
        drinksToDGV("DSH_SB", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_bbq_Click(sender As Object, e As EventArgs) Handles menu_btn_bbq.Click
        drinksToDGV("DSH_BB", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_ib_Click(sender As Object, e As EventArgs) Handles menu_btn_ib.Click
        drinksToDGV("DSH_IB", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_es_Click(sender As Object, e As EventArgs) Handles menu_btn_es.Click
        drinksToDGV("DSH_ES", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_ucb_Click(sender As Object, e As EventArgs) Handles menu_btn_ucb.Click
        drinksToDGV("DSH_UC", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_tdd_Click(sender As Object, e As EventArgs) Handles menu_btn_tdd.Click
        drinksToDGV("DSH_TD", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_cc_Click(sender As Object, e As EventArgs) Handles menu_btn_cc.Click
        drinksToDGV("DSH_CC", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_pp_Click(sender As Object, e As EventArgs) Handles menu_btn_pp.Click
        drinksToDGV("DSH_PP", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_cp_Click(sender As Object, e As EventArgs) Handles menu_btn_cp.Click
        drinksToDGV("DSH_CP", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_h_Click(sender As Object, e As EventArgs) Handles menu_btn_h.Click
        drinksToDGV("DSH_HS", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_l_Click(sender As Object, e As EventArgs) Handles menu_btn_l.Click
        drinksToDGV("DSH_LS", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_cs_Click(sender As Object, e As EventArgs) Handles menu_btn_cs.Click
        drinksToDGV("DSH_CS", DRINKS_SIZEG)
    End Sub

    Private Sub menu_btn_spam_Click(sender As Object, e As EventArgs) Handles menu_btn_spam.Click
        drinksToDGV("DSH_SS", DRINKS_SIZEG)
    End Sub


    ''

    Private Sub account_delbtn_Click(sender As Object, e As EventArgs) Handles account_delbtn.Click
        panconmembersdelete.ShowDialog()

        Dim Delete As String

        SelectedAdmin = accounts_dgv.Item(0, accounts_dgv.CurrentRow.Index).Value

        Delete = MsgBox("Are you sure you want to delete Administrator " + SelectedAdmin + "?", vbYesNo + vbQuestion, "Message")
        If Delete = vbYes Then
            With Command
                .Connection = Connect
                .CommandText = "DELETE FROM tblAdministrators WHERE username = '" & SelectedAdmin & "'"
                .ExecuteNonQuery()
            End With
            AccountsDGV()
            MsgBox("Administrator " + SelectedAdmin + " successfully deleted!", vbOKOnly + vbInformation, "Message")
        End If
    End Sub



    Private Sub account_addbtn_Click(sender As Object, e As EventArgs) Handles account_addbtn.Click
        formadmincreatenew.ShowDialog()
    End Sub

    Private Sub account_editbtn_Click(sender As Object, e As EventArgs) Handles account_editbtn.Click
        SelectedAdmin = accounts_dgv.Item(0, accounts_dgv.CurrentRow.Index).Value
        userSelected = SelectedAdmin
        typeadminpassword.ShowDialog()
    End Sub

    ''
    Private Sub ChangePass()
        Dim Username As String
        SelectedAdmin = accounts_dgv.Item(0, accounts_dgv.CurrentRow.Index).Value
        Username = SelectedAdmin
        accountsEdit.lUsername.Text = Username
    End Sub



    Private Sub btnmembers_del_Click(sender As Object, e As EventArgs) Handles btnmembers_del.Click
        deletemem.ShowDialog()
        Dim Delete As String

        SelectedMember = dgv_members.Item(0, dgv_members.CurrentRow.Index).Value

        Delete = MsgBox("Are you sure you want to delete this Member " + SelectedMember + "?", vbYesNo + vbQuestion, "Message")
        If Delete = vbYes Then
            With Command
                .Connection = Connect
                .CommandText = "DELETE FROM tblcustomers WHERE cus_no = '" & SelectedMember & "'"
                .ExecuteNonQuery()
            End With
            membersDGV()
            MsgBox("Member " + SelectedMember + " successfully deleted!", vbOKOnly + vbInformation, "Message")
        End If
    End Sub

    Private Sub btnmembers_add_Click(sender As Object, e As EventArgs) Handles btnmembers_add.Click

        addcustomer.ShowDialog()
    End Sub

    Private Sub dgvorders_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvorders.RowStateChanged
        updateTotalOrders()
    End Sub

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        cashcard.ShowDialog()
    End Sub


    Public Sub DGVINV()
        DGVINV("SELECT p.prod_code, p.prod_name, i.inv_qty, p.prod_class FROM tblproducts AS p, tblinventory AS i WHERE p.prod_code = i.inv_prod_code")
    End Sub

    Public Sub DGVINV(sql As String)
        inventorydgv.Rows.Clear()
        With Command
            .Connection = Connect
            .CommandText = sql
        End With
        Reader = Command.ExecuteReader

        If Reader.HasRows Then
            While Reader.Read
                inventorydgv.Rows.Add(Reader.Item(0), Reader.Item(1), Reader.Item(2), Reader.Item(3))
            End While
        End If
        Reader.Close()
    End Sub

    'start search shit'
    Private Sub updateSearchInput(ByVal command As String)

        cboinventory2.DropDownStyle = ComboBoxStyle.DropDown
        cboinventory2.FlatStyle = FlatStyle.Standard

        Dim cmd As New MySqlCommand
        Dim dr As MySqlDataReader
        cboinventory2.Items.Clear()
        cboinventory2.AutoCompleteCustomSource.Clear()
        With cmd
            .Connection = Connect
            .CommandText = command
        End With
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                cboinventory2.Items.Add(dr.Item(0))
                cboinventory2.AutoCompleteCustomSource.Add(dr.Item(0))
            End While
        End If
        dr.Close()

    End Sub



    Private Sub inv_add_Click(sender As Object, e As EventArgs) Handles inv_edit.Click
        frminvedit.ShowDialog()
    End Sub



    ''
    Private Sub cboinventory1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboinventory1.SelectedIndexChanged
        'Reset components

        cboinventory2.Text = ""
        cboinventory2.Items.Clear()
        DGVINV()
        If cboinventory1.SelectedIndex = -1 Then
            cboinventory2.Enabled = False
            Exit Sub
        End If
        cboinventory2.Enabled = True

        Select Case cboinventory1.SelectedIndex
            Case 0
                ' prodcode
                updateSearchInput("SELECT p.prod_code FROM tblproducts p, tblinventory i WHERE p.prod_code = i.inv_prod_code")
            Case 1
                ' prodename
                updateSearchInput("SELECT prod_name FROM tblproducts")

            Case 2
                ' availability
                cboinventory2.DropDownStyle = ComboBoxStyle.DropDownList
                cboinventory2.FlatStyle = FlatStyle.Flat
                cboinventory2.Items.Clear()
                cboinventory2.Items.Add("drinks_icetea")
                cboinventory2.Items.Add("drinks_smoothie")
                cboinventory2.Items.Add("drinks_milktea")
                cboinventory2.Items.Add("For sharing")
                cboinventory2.Items.Add("Pasta")
                cboinventory2.Items.Add("Sandwich")
                cboinventory2.Items.Add("SILOG")
        End Select
    End Sub

    Private Sub cboinventory2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboinventory2.SelectedIndexChanged, cboinventory2.TextChanged
        If cboinventory2.SelectedIndex = -1 And cboinventory2.Text = "" Then
            DGVINV()
            Exit Sub
        End If

        Select Case cboinventory1.SelectedIndex
            Case 0
                ' prod_code
                DGVINV("SELECT p.prod_code, p.prod_name, i.inv_qty, p.prod_class  FROM tblproducts p, tblinventory i WHERE i.inv_prod_code = p.prod_code AND p.prod_code LIKE '%" & cboinventory2.Text & "%'")
            Case 1
                ' prod_name 
                DGVINV("SELECT p.prod_code, p.prod_name, i.inv_qty, p.prod_class  FROM tblproducts p, tblinventory i WHERE i.inv_prod_code = p.prod_code AND p.prod_name LIKE '%" & cboinventory2.Text & "%'")

            Case 2
                ' type
                DGVINV("Select p.prod_code, p.prod_name, i.inv_qty, p.prod_class  FROM tblproducts p, tblinventory i WHERE i.inv_prod_code = p.prod_code And p.prod_class='" & cboinventory2.Text & "'")

        End Select

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        SelectedMember = dgv_members.Item(0, dgv_members.CurrentRow.Index).Value
        userSelected = SelectedMember
        frmmemers_editchoices.ShowDialog()
    End Sub

    Private Sub btnclearorder_Click(sender As Object, e As EventArgs) Handles btnclearorder.Click
        frmordersadminpassclear.ShowDialog()
    End Sub

    Private Sub btnDeleteOrders_Click(sender As Object, e As EventArgs) Handles btnDeleteOrders.Click
        typeadminpassworddelete.ShowDialog()
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As EventArgs)

    End Sub


End Class

