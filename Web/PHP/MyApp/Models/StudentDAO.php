<?php
class StudentDAO {
    public static function getConnection(){
        try {
            $connection = new PDO("mysql:host=localhost;dbname=test","root","password");
            return $connection;
        } catch (Exception $ex) { }
        return NULL;
    }
    public  function addRole($Name){
        $con= $this->getConnection();
        if($con!=NULL){
            $stmt=$con->prepare("INSERT INTO role(RoleName) VALUES (:name)");
            $stmt->bindParam(":name", $Name);
            $stmt->execute();
            return "Data Added Successfully.";
        }
        return "Can't Connect";
    }
    public  function addStudent($name,$email,$mobile){
        $connection=  $this->getConnection();
        if($connection!=NULL){
            $statement= $connection->prepare("INSERT INTO student (Name,Email,Mobile) VALUES(:name,:email,:mobile)");
            $statement->bindParam(":name", $name);
            $statement->bindParam(":email", $email);
            $statement->bindParam(":mobile",$mobile);
            $statement->execute();
            return "Student data added Successfully.";
        }
        return "Connection can't established.";
    }
    public  function findById($Id){
        $connection = $this->getConnection();
        if($connection!=NULL){
            $sql= "SELECT * FROM student WHERE Id=".$Id;
            $result=$connection->query($sql);
            if($result!==FALSE){
                $count=$result->rowCount();
            return $count;
            }
        }
        return 0;  
    }
    public  function editStudent($Id,$Name,$Email,$Mobile){
        $connection = $this->getConnection();
        if($connection!=NULL){
            if($this->findById($Id)!=0){
                $statement=$connection->prepare("UPDATE `student` SET Name=:name,Email=:email,Mobile=:mobile WHERE Id=:id");
                $statement->bindParam(":name", $Name);
                $statement->bindParam(":email", $Email);
                $statement->bindParam(":mobile", $Mobile);
                $statement->bindParam(":id", $Id);
                $statement->execute();
                return "Data Updated.";
            }else{
                return "Data Not Found.!";
            }
        }
        return "Connection can't established.";        
    }
    public  function getStudent($Id){
        $connection = $this->getConnection();
        if($connection!=NULL){
            $result = $connection->query("SELECT * FROM student WHERE Id=".$Id);
            return $result;
        }
    }
    public  function deleteStudent($Id){
        if($this->findById($Id)!=0){
            $Connection =  $this->getConnection();
            $Connection->exec("DELETE FROM student WHERE Id =".$Id);
            return "Data Deleted successfully.";
        }else{
            return "Data not found.";
        }
    }
}

