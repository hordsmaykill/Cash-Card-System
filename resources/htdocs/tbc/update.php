<?php
	
    define('HOST', 'localhost');
    define('USER', 'root');
    define('PASS', '');
    define('DB', 'dbtbc');

    $conn = mysqli_connect(HOST, USER, PASS, DB);
    
    // $cusNo = $_POST['cusNo'];
    $cusNo ="tbc123";

    $sql = "UPDATE tbltransaction SET cus_no='$cusNo' WHERE id='1';";

	$res = mysqli_query($conn, $sql);

	if($res) {
        echo 'success';
    } else {
        echo 'fail';
    }
    
    mysqli_close($conn);
?>