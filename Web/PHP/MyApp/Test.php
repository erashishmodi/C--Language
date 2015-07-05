<?php
require './Models/StudentDAO.php';
 $obj=new \StudentDAO();
        $message=$obj->editStudent(1,"Ashish","i@B.com","47848");        
        echo $message;