<?php
  require_once('Database.php');

  if (isset($_GET['controller']) && isset($_GET['action']))
  {
    $controller = $_GET['controller'];
    $action     = $_GET['action'];
  } 
  else
  {
    $controller = 'view_result';
    $action     = 'home';
  }

  require_once('views/layout.php');
?>