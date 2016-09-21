<?php
	
   require "conn.php";
    
    $customerId = $_POST['customerId'];

    $sql = "UPDATE isTransacting FROM tblcustomers WHERE isTransacting=true;";

	$res = mysqli_query($conn, $sql);

	if(mysqli_fetch_array($res)) {
        echo 'success';
    } else {
        echo 'fail';
    }
    
    mysqli_close($conn);
?>