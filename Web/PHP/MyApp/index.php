<?php
require_once './Models/StudentDAO.php';
$id="";
$name="";
$email="";
$mobile="";
$message="";
$action="";
if(isset($_POST['cmd'])){
    $action=$_POST['cmd'];
    if($action === "Add"){
        $obj=new \StudentDAO();
        $message=  $obj->addStudent($_POST['name'], $_POST['email'], $_POST['mobile']);
    }else if($action=="Edit"){
        $id=$_POST['id'];
        $obj=new \StudentDAO();
        $r=$obj->getStudent($id);
        $rec=$r->fetch();
        $name=$rec['Name'];
        $mobile=$rec['Mobile'];
        $email=$rec['Email'];        
    }else if($action== "Save"){
         $obj=new \StudentDAO();
        $message=$obj->editStudent($_POST['id'], $_POST['name'],$_POST['email'], $_POST['mobile']);               
    }else if ($action=="Delete"){
        $obj= new StudentDAO();
        $obj->deleteStudent($_POST['id']);        
    }
}
?>
<!DOCTYPE html>
<html>
    <head>
        <title>Student Record</title>
        <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    </head>
    <body>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <form class="form-horizontal" id="form1" action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
                        <fieldset>
                            <legend>Student Information.</legend>
                            <p>
                                <input type="hidden" name="id" value="<?php echo $id;?>" />
                            </p>                                 
                            <div class="form-group">
                                <label class="col-sm-2 control-label" for="name">Student Name</label>
                                <div class="col-md-6">
                                    <input class="form-control" type="text" id="name" value="<?php echo $name; ?>" name="name" required />
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="col-sm-2 control-label" for="email">Student Email</label>
                                <div class="col-md-6">
                                    <input class="form-control"  type="email" id="email" value="<?php echo $email; ?>"  name="email" required />    
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label" for="mobile">Student Mobile</label>
                                <div class="col-md-6">
                                    <input class="form-control" type="number" id="mobile"  value="<?php echo $mobile; ?>"  name="mobile" required /> 
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <?php
                                if($action==="Edit"){                                    
                                    echo '<input type="submit" class="btn btn-info" value="Save" name="cmd"> ';
                                }else{
                                    echo '<input type="submit" class="btn btn-primary" value="Add" name="cmd">';                                   
                                }                                
                                ?>    
                                </div>
                            </div>
                        </fieldset>                            
                    </form>
                    <p><?php echo $message;?></p>
                </div>                
            </div>
            <div class="row">
                <div class="col-md-12">
                    <table class="table table-bordered table-hover table-striped">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Name</th>
                                <th>Email</th>
                                <th>Mobile</th>
                                <th colspan="2">ACTION</th>
                            </tr>
                        </thead>
                        <tbody>
                            <?php
                            $connnection =  StudentDAO::getConnection();
                            $result=$connnection->query("SELECT * FROM student");                            
                            while ($r = $result->fetch()): ?>
                            <tr>
                                <td><?php echo htmlspecialchars($r['Id'])?></td>
                                <td><?php echo htmlspecialchars($r['Name'])?></td>
                                <td><?php echo htmlspecialchars($r['Email']); ?></td>
                                <td><?php echo htmlspecialchars($r['Mobile']); ?></td>
                                <td><form action="<?php echo $_SERVER['PHP_SELF'];?>" method="post"><input name="id" type="hidden" value="<?php echo htmlspecialchars($r['Id']); ?>"><input class="btn  btn-info" type="submit" name="cmd" value="Edit"></form></td>
                                <td><form action="<?php echo $_SERVER['PHP_SELF'];?>" method="post"><input name="id" type="hidden" value="<?php echo htmlspecialchars($r['Id']); ?>"><input class="btn btn-danger" type="submit" name="cmd" onclick="return (confirm())" value="Delete"></form></td>
                            </tr>
                             <?php endwhile; ?>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </body>
</html>