<?php
  function call($controller, $action)
  {
    require_once('controllers/' . $controller . '_controller.php');

    switch($controller)
    {
      case 'view_result':
        require_once('Database.php');
        require_once('models/Contest.php');
        require_once('models/Branch.php');
        require_once('models/Contestant.php');
        require_once('models/Dive.php');
        require_once('models/Point.php');
        $controller = new ViewResultController();
      break;
    }

    $controller->{ $action }();
  }

  $controllers = array(
      'view_result' => ['home']
  );

  call($controller, $action);
?>