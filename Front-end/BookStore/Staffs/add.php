<?php
    include_once __DIR__ . '/../CallAPI.php';
    if(isset($_POST["Add"])){
        $data_array = array(
            "Name"=>$_POST["name"],
            "Email"=>$_POST["email"],
            "Phone"=>$_POST["phone"],
            "RoleId"=>$_POST["roleId"],
            "Address" => $_POST["address"]
        );
        $result = CallAPI("user","POST",$data_array);
        if(isset($result["Error"]) || isset($result["errors"])){
            print_r($result);
        }else{
            echo '<script>location.href = "index.php";</script>';
        }
    }
?>