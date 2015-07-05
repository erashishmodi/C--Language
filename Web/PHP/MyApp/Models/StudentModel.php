<?php
class StudentModel {
    private $Id;
    private $Name;
    private $Email;
    private $Mobile;
    public function getId(){
        return $this->Id;
    }
    public function setId($Id){
        $this->Id=$Id;
    }
     public function getName(){
        return $this->Name;
    }
    public function setName($Name){
        $this->Name=$Name;
    }
     public function getEmail(){
        return $this->Email;
    }
    public function setEmail($Email){
        $this->Id=$Email;
    }
    public function getMobile(){
        return $this->Mobile;
    }
    public function setMobile($Mobile){
        $this->Mobile=$Mobile;
    }      
}
