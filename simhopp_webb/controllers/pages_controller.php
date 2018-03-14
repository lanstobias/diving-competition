<?php
  class PagesController
  {
    public function home()
    {
      $first_name = 'Bob';
      $last_name  = 'Dylan';
      require_once('views/pages/home.php');
    }
  }
?>