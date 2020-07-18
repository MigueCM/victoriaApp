<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="VictoriaApp.Dashboard" %>


<!DOCTYPE html>
<html lang="en">

<head>
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>Wagondash Premium Bootstrap Admin Dashboard Template</title>
  <!-- base:css -->
  <link rel="stylesheet" href="vendors/mdi/css/materialdesignicons.min.css">
  <link rel="stylesheet" href="vendors/css/vendor.bundle.base.css">
  <!-- endinject -->
  <!-- plugin css for this page -->
  <!-- End plugin css for this page -->
  <!-- inject:css -->
  <link rel="stylesheet" href="css/horizontal-layout-light/style.css">
  <link rel="stylesheet" href="css/estilos.css">
  <!-- endinject -->
  <link rel="shortcut icon" href="images/favicon.png" />
</head>

<body>
  <div class="container-scroller">
    <!-- partial:partials/_horizontal-navbar.html -->
    <div class="horizontal-menu">
      <nav class="navbar top-navbar col-lg-12 col-12 p-0">
        <div class="container">
          <div class="text-center navbar-brand-wrapper d-flex align-items-center justify-content-center">
            <a class="navbar-brand brand-logo" href="index.html"><img src="images/logo-dark.svg" alt="logo"/></a>
            <a class="navbar-brand brand-logo-mini" href="index.html"><img src="images/logo-mini.svg" alt="logo"/></a>
          </div>
          <div class="navbar-menu-wrapper d-flex align-items-center justify-content-end">
            <ul class="navbar-nav mr-lg-2">
              <li class="nav-item d-none d-sm-block dropdown arrow-none">
                  <button type="button" class="btn btn-success btn-icon-text dropdown-toggle ml-3" data-toggle="dropdown" id="profileDropdown6">
                      <i class="mdi mdi-plus-circle btn-icon-prepend"></i>                                                    
                      Add Schedule
                  </button>
                  <div class="dropdown-menu dropdown-menu-left navbar-dropdown" aria-labelledby="profileDropdown6">
                    <a class="dropdown-item text-primary">
                     <i class="mdi mdi-google-analytics"></i> Product Analysis
                    </a>
                    <a class="dropdown-item text-primary">
                      <i class="mdi mdi-sale"></i> Territory sales
                    </a>
                    <a class="dropdown-item text-primary">
                      <i class="mdi mdi-account-card-details"></i> sales order details
                    </a>
                    <a class="dropdown-item text-primary">
                        <i class="mdi mdi-counter"></i> Product Line sales
                    </a>
                  </div>
              </li>
              <li class="nav-item nav-search d-none d-sm-block">
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="search">
                      <i class="mdi mdi-magnify"></i>
                    </span>
                  </div>
                  <input type="text" class="form-control" placeholder="search" aria-label="search" aria-describedby="search">
                </div>
              </li>
            </ul>
            <ul class="navbar-nav navbar-nav-right">
              <li class="nav-item count-indicator nav-profile dropdown">
                <span class="count">3</span>
                <a class="nav-link  dropdown-toggle" href="#" data-toggle="dropdown" id="profileDropdown">
                  <span class="nav-profile-name">Hi, Lucille Wilkins</span>
                  <img src="images/faces/face28.png" alt="profile"/>
                </a>
                <div class="dropdown-menu dropdown-menu-right navbar-dropdown" aria-labelledby="profileDropdown">
                  <a class="dropdown-item text-primary">
                    <i class="mdi mdi-settings"></i>
                    Settings
                  </a>
                  <a class="dropdown-item text-primary">
                    <i class="mdi mdi-message text-primary"></i>
                    Messages
                  </a>
                </div>
              </li>
              <li class="nav-item dropdown count-indicator arrow-none">
                  <span class="count bg-success">3</span>
                <a class="nav-link dropdown-toggle d-flex align-items-center justify-content-center" id="notificationDropdown" href="#" data-toggle="dropdown">
                  <i class="mdi mdi-bell-outline mx-0"></i>
                </a>
                <div class="dropdown-menu dropdown-menu-right navbar-dropdown preview-list" aria-labelledby="notificationDropdown">
                  <p class="mb-0 font-weight-normal float-left dropdown-header">Notifications</p>
                  <a class="dropdown-item preview-item">
                    <div class="preview-thumbnail">
                      <div class="preview-icon bg-success">
                        <i class="mdi mdi-information mx-0"></i>
                      </div>
                    </div>
                    <div class="preview-item-content">
                      <h6 class="preview-subject font-weight-normal">Application Error</h6>
                      <p class="font-weight-light small-text mb-0">
                        Just now
                      </p>
                    </div>
                  </a>
                  <a class="dropdown-item preview-item">
                    <div class="preview-thumbnail">
                      <div class="preview-icon bg-warning">
                        <i class="mdi mdi-settings mx-0"></i>
                      </div>
                    </div>
                    <div class="preview-item-content">
                      <h6 class="preview-subject font-weight-normal">Settings</h6>
                      <p class="font-weight-light small-text mb-0">
                        Private message
                      </p>
                    </div>
                  </a>
                  <a class="dropdown-item preview-item">
                    <div class="preview-thumbnail">
                      <div class="preview-icon bg-info">
                        <i class="mdi mdi-account-box mx-0"></i>
                      </div>
                    </div>
                    <div class="preview-item-content">
                      <h6 class="preview-subject font-weight-normal">New user registration</h6>
                      <p class="font-weight-light small-text mb-0">
                        2 days ago
                      </p>
                    </div>
                  </a>
                </div>
              </li>
            </ul>
            <button class="navbar-toggler navbar-toggler-right d-lg-none align-self-center" type="button" data-toggle="horizontal-menu-toggle">
              <span class="mdi mdi-menu"></span>
            </button>
          </div>
        </div>
      </nav>
      <nav class="bottom-navbar">
        <div class="container">
          <ul class="nav page-navigation">
            <li class="nav-item">
              <a class="nav-link" href="index.html">
                <i class="mdi mdi-view-dashboard-outline menu-icon"></i>
                <span class="menu-title">Dashboard</span>
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="pages/widgets/widgets.html">
                <i class="mdi mdi-airplay menu-icon"></i>
                <span class="menu-title">Widgets</span>
              </a>
            </li>
            <li class="nav-item mega-menu">
              <a href="#" class="nav-link">
                <i class="mdi mdi-puzzle-outline menu-icon"></i>
                <span class="menu-title">UI Elements</span>
                <i class="menu-arrow"></i>
              </a>
              <div class="submenu">
                <div class="col-group-wrapper row">
                  <div class="col-group col-md-5">
                    <div class="row">
                      <div class="col-12">
                        <p class="category-heading">Basic Elements</p>
                        <div class="submenu-item">
                          <div class="row">
                            <div class="col-md-4">
                              <ul>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/accordions.html">Accordion</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/buttons.html">Buttons</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/badges.html">Badges</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/breadcrumbs.html">Breadcrumbs</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/dropdowns.html">Dropdown</a></li>
                              </ul>
                            </div>
                            <div class="col-md-4">
                              <ul>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/modals.html">Modals</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/progress.html">Progress bar</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/pagination.html">Pagination</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/tabs.html">Tabs</a></li>
                              </ul>
                            </div>
                            <div class="col-md-4">
                              <ul>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/typography.html">Typography</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/tooltips.html">Tooltip</a></li>
                              </ul>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="col-group col-md-4">
                    <div class="row">
                      <div class="col-12">
                        <p class="category-heading">Advanced Elements</p>
                        <div class="submenu-item">
                          <div class="row">
                            <div class="col-md-6">
                              <ul>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/dragula.html">Dragula</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/carousel.html">Carousel</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/clipboard.html">Clipboard</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/context-menu.html">Context Menu</a></li>
                              </ul>
                            </div>
                            <div class="col-md-6">
                              <ul>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/loaders.html">Loader</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/slider.html">Slider</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/popups.html">Popup</a></li>
                                <li class="nav-item"><a class="nav-link" href="pages/ui-features/notifications.html">Notification</a></li>
                              </ul>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="col-group col-md-3">
                    <p class="category-heading">Icons</p>
                    <ul class="submenu-item">
                      <li class="nav-item"><a class="nav-link" href="pages/icons/flag-icons.html">Flag Icons</a></li>
                      <li class="nav-item"> <a class="nav-link" href="pages/icons/mdi.html">Mdi icons</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/icons/font-awesome.html">Font Awesome</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/icons/simple-line-icon.html">Simple Line Icons</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/icons/themify.html">Themify Icons</a></li>
                    </ul>
                  </div>
                </div>
              </div>
            </li>
            <li class="nav-item">
              <a href="#" class="nav-link">
                <i class="mdi mdi-file-document-box-outline menu-icon"></i>
                <span class="menu-title">Forms</span>
                <i class="menu-arrow"></i></a>
              <div class="submenu">
                <ul class="submenu-item">
                  <li class="nav-item"><a class="nav-link" href="pages/forms/basic_elements.html">Basic Elements</a></li>
                  <li class="nav-item"><a class="nav-link" href="pages/forms/advanced_elements.html">Advanced Elements</a></li>
                  <li class="nav-item"><a class="nav-link" href="pages/forms/validation.html">Validation</a></li>
                  <li class="nav-item"><a class="nav-link" href="pages/forms/wizard.html">Wizard</a></li>
                  <li class="nav-item"><a class="nav-link" href="pages/forms/text_editor.html">Text Editor</a></li>
                  <li class="nav-item"><a class="nav-link" href="pages/forms/code_editor.html">Code Editor</a></li>
                </ul>
              </div>
            </li>
            <li class="nav-item mega-menu">
              <a href="#" class="nav-link">
                <i class="mdi mdi-finance menu-icon"></i>
                <span class="menu-title">Data</span>
                <i class="menu-arrow"></i></a>
              <div class="submenu">
                <div class="col-group-wrapper row">
                  <div class="col-group col-md-6">
                    <p class="category-heading">Charts</p>
                    <div class="submenu-item">
                      <div class="row">
                        <div class="col-md-6">
                          <ul>
                            <li class="nav-item"><a class="nav-link" href="pages/charts/chartjs.html">Chart Js</a></li>
                            <li class="nav-item"><a class="nav-link" href="pages/charts/morris.html">Morris</a></li>
                            <li class="nav-item"><a class="nav-link" href="pages/charts/flot-chart.html">Flot</a></li>
                            <li class="nav-item"><a class="nav-link" href="pages/charts/google-charts.html">Google Chart</a></li>
                          </ul>
                        </div>
                        <div class="col-md-6">
                          <ul>
                            <li class="nav-item"><a class="nav-link" href="pages/charts/sparkline.html">Sparkline</a></li>
                            <li class="nav-item"><a class="nav-link" href="pages/charts/c3.html">C3 Chart</a></li>
                            <li class="nav-item"><a class="nav-link" href="pages/charts/chartist.html">Chartist</a></li>
                            <li class="nav-item"><a class="nav-link" href="pages/charts/justGage.html">JustGage</a></li>
                          </ul>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="col-group col-md-3">
                    <p class="category-heading">Table</p>
                    <ul class="submenu-item">
                      <li class="nav-item"><a class="nav-link" href="pages/tables/basic-table.html">Basic Table</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/tables/data-table.html">Data Table</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/tables/js-grid.html">Js-grid</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/tables/sortable-table.html">Sortable Table</a></li>
                    </ul>
                  </div>
                  <div class="col-group col-md-3">
                    <p class="category-heading">Maps</p>
                    <ul class="submenu-item">
                      <li class="nav-item"><a class="nav-link" href="pages/maps/mapael.html">Mapael</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/maps/vector-map.html">Vector Map</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/maps/google-maps.html">Google Map</a></li>
                    </ul>
                  </div>
                </div>
              </div>
            </li>
            <li class="nav-item mega-menu">
              <a href="#" class="nav-link">
                <i class="mdi mdi-codepen menu-icon"></i>
                <span class="menu-title">Sample Pages</span>
                <i class="menu-arrow"></i></a>
              <div class="submenu">
                <div class="col-group-wrapper row">
                  <div class="col-group col-md-3">
                    <p class="category-heading">User Pages</p>
                    <ul class="submenu-item">
                      <li class="nav-item"><a class="nav-link" href="pages/samples/login.html">Login</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/login-2.html">Login 2</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/register.html">Register</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/register-2.html">Register 2</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/lock-screen.html">Lockscreen</a></li>
                    </ul>
                  </div>
                  <div class="col-group col-md-3">
                    <p class="category-heading">Error Pages</p>
                    <ul class="submenu-item">
                      <li class="nav-item"><a class="nav-link" href="pages/samples/error-400.html">400</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/error-404.html">404</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/error-500.html">500</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/error-505.html">505</a></li>
                    </ul>
                  </div>
                  <div class="col-group col-md-3">
                    <p class="category-heading">E-commerce</p>
                    <ul class="submenu-item">
                      <li class="nav-item"><a class="nav-link" href="pages/samples/invoice.html">Invoice</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/pricing-table.html">Pricing Table</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/orders.html">Orders</a></li>
                    </ul>
                  </div>
                  <div class="col-group col-md-3">
                    <p class="category-heading">General</p>
                    <ul class="submenu-item">
                      <li class="nav-item"><a class="nav-link" href="pages/samples/search-results.html">Search Results</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/profile.html">Profile</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/timeline.html">Timeline</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/news-grid.html">News grid</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/portfolio.html">Portfolio</a></li>
                      <li class="nav-item"><a class="nav-link" href="pages/samples/faq.html">FAQ</a></li>
                    </ul>
                  </div>
                </div>
              </div>
            </li>
            <li class="nav-item">
              <a href="#" class="nav-link">
                <i class="mdi mdi-image-filter menu-icon"></i>
                <span class="menu-title">Apps</span>
                <i class="menu-arrow"></i></a>
              <div class="submenu">
                <ul class="submenu-item">
                  <li class="nav-item"><a class="nav-link" href="pages/apps/email.html">Email</a></li>
                  <li class="nav-item"><a class="nav-link" href="pages/apps/calendar.html">Calendar</a></li>
                  <li class="nav-item"><a class="nav-link" href="pages/apps/todo.html">Todo List</a></li>
                  <li class="nav-item"><a class="nav-link" href="pages/apps/gallery.html">Gallery</a></li>
                </ul>
              </div> 
            </li>
            <li class="nav-item">
              <a href="http://www.urbanui.com/wagondash/docs/documentation.html" target="_blank" class="nav-link">
                <i class="mdi mdi-file-document-box-outline menu-icon"></i>
                <span class="menu-title">Documentation</span></a>
            </li>
          </ul>
        </div>
      </nav>
    </div>
    <!-- partial -->
    <div class="container-fluid page-body-wrapper">
      <div class="main-panel">
        <div class=" p-0 pt-4 px-4">
          
            <div class="row">

                <div class="col-md-8">

                    <div class="row">

                        <div class="col-md-4">

                        <div class="card card-shadow">
                            <img src="images/video.png" class="card-img-top" alt="...">
                            <div class="card-body card-body-panel">
                              <h5 class="card-title text-primary card-title-panel">1. Card title that wraps to a new line</h5>
                              <p class="card-text pl-3"> Por <span class="text-primary">Lorem Ipsus</span></p>
                              <p class="card-text pl-3">
                                  <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                                  <i class="fas fa-play text-primary"></i> 8,365
                              </p>
                                <div class="text-center">
                                    <a href="#" class="btn btn-primary">Empezar</a>
                                </div>
                              
  
                            </div>
                         </div>

                    </div>

                        <div class="col-md-4">

                        <div class="card card-shadow">
                            <img src="images/video.png" class="card-img-top" alt="...">
                            <div class="card-body card-body-panel">
                              <h5 class="card-title text-primary card-title-panel">2. Card title that wraps to a new line</h5>
                              <p class="card-text pl-3"> Por <span class="text-primary">Lorem Ipsus</span></p>
                              <p class="card-text pl-3">
                                  <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                                  <i class="fas fa-play text-primary"></i> 8,365
                              </p>
                                <div class="text-center">
                                    <a href="#" class="btn btn-primary">Empezar</a>
                                </div>
                              
  
                            </div>
                         </div>

                    </div>

                        <div class="col-md-4">

                        <div class="card card-shadow">
                            <img src="images/video.png" class="card-img-top" alt="...">
                            <div class="card-body card-body-panel">
                              <h5 class="card-title text-primary card-title-panel">3. Card title that wraps to a new line</h5>
                              <p class="card-text pl-3"> Por <span class="text-primary">Lorem Ipsus</span></p>
                              <p class="card-text pl-3">
                                  <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                                  <i class="fas fa-play text-primary"></i> 8,365
                              </p>
                                <div class="text-center">
                                    <a href="#" class="btn btn-primary">Empezar</a>
                                </div>
                              
  
                            </div>
                         </div>

                    </div>

                        <div class="col-md-4">
                       <div class="card-bloqueado">
                           <div class="image-bloqueado">
                               <img src="images/lock.png" alt="Alternate Text" />
                           </div>
                           
                           <div class="card card-shadow ">
                            <img src="images/video.png" class="card-img-top" alt="...">
                            <div class="card-body card-body-panel b-white">
                              <h5 class="card-title text-primary card-title-panel">6. Card title that wraps to a new line</h5>
                              <p class="card-text pl-3"> Por <span class="text-primary">Lorem Ipsus</span></p>
                              <p class="card-text pl-3">
                                  <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                                  <i class="fas fa-play text-primary"></i> 8,365
                              </p>
                                <div class="text-center">
                                    <a href="#" class="btn btn-primary">Empezar</a>
                                </div>
                              
  
                            </div>
                         </div>
                       </div>

                        

                    </div>

                        <div class="col-md-4">
                       <div class="card-bloqueado">
                           <div class="image-bloqueado">
                               <img src="images/lock.png" alt="Alternate Text" />
                           </div>
                           
                           <div class="card card-shadow ">
                            <img src="images/video.png" class="card-img-top" alt="...">
                            <div class="card-body card-body-panel b-white">
                              <h5 class="card-title text-primary card-title-panel">6. Card title that wraps to a new line</h5>
                              <p class="card-text pl-3"> Por <span class="text-primary">Lorem Ipsus</span></p>
                              <p class="card-text pl-3">
                                  <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                                  <i class="fas fa-play text-primary"></i> 8,365
                              </p>
                                <div class="text-center">
                                    <a href="#" class="btn btn-primary">Empezar</a>
                                </div>
                              
  
                            </div>
                         </div>
                       </div>

                        

                    </div>

                        <div class="col-md-4">
                       <div class="card-bloqueado">
                           <div class="image-bloqueado">
                               <img src="images/lock.png" alt="Alternate Text" />
                           </div>
                           
                           <div class="card card-shadow ">
                            <img src="images/video.png" class="card-img-top" alt="...">
                            <div class="card-body card-body-panel b-white">
                              <h5 class="card-title text-primary card-title-panel">6. Card title that wraps to a new line</h5>
                              <p class="card-text pl-3"> Por <span class="text-primary">Lorem Ipsus</span></p>
                              <p class="card-text pl-3">
                                  <i class="fas fa-star color-star"></i> 5 &nbsp;&nbsp;&nbsp;
                                  <i class="fas fa-play text-primary"></i> 8,365
                              </p>
                                <div class="text-center">
                                    <a href="#" class="btn btn-primary">Empezar</a>
                                </div>
                              
  
                            </div>
                         </div>
                       </div>

                        

                    </div>


                    </div>

                    

                </div>

                <div class="col-md-4">

                    <div class="panel-right">

                        

                        <div class="row" >

                            <div class="col-12">

                                <div class="panel-image text-center">

                                    <img src="#" alt="Alternate Text" />

                                    <h1 class="color-black ">Lorem Ipsus</h1>

                                    <span>Lima, Perú</span>

                                </div>

                                <div class="progress progress-xl mt-2">
                                  <div class="progress-bar bg-primary" role="progressbar" style="width: 50%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">50% de avance</div>
                                </div>

                            </div>

                            <div class="col-6">
                                <button class="btn btn-block btn-primary btn-options">PANEL</button>
                            </div>

                            <div class="col-6">
                                <button class="btn btn-block btn-primary btn-options"> MODULOS</button>
                            </div>

                            <div class="col-12">

                                <h2 class="text-primary mt-4"> Próximos Webinars</h2>

                                <div>

                                    <div class="accordion accordion-solid-header" id="accordion-1" role="tablist">
                                        <div class="card webinar-shadow">
                                            <div class="card-header" role="tab" id="heading-1">
                                                <h6 class="mb-0">
                                                <a data-toggle="collapse" href="#collapse-1" aria-expanded="false" aria-controls="collapse-1" class="collapsed">
                                                    <span class="h3 text-primary">Lorem Ipsus</span>
                                                    <span class="webinar-autor">Por Lorem Ipsus</span>
                                                    
                                                </a>
                                                </h6>
                                            </div>
                                            <div id="collapse-1" class="collapse" role="tabpanel" aria-labelledby="heading-1" data-parent="#accordion-1" style="">
                                            <div class="card-body">
                                            <div class="row">
                                                <div class="col-3">
                                                <img src="images/webinar.jpg" class="mw-100" alt="image">                              
                                                </div>
                                                <div class="col-9">
                                                <p class="mb-0 color-white">You can pay for the product you have purchased using credit cards, debit cards, or via online banking. 
                                                We also on-delivery services.</p>                             
                                                </div>
                                            </div>
                                            </div>
                                        </div>
                                        </div>

                                        <div class="card webinar-shadow">
                                            <div class="card-header" role="tab" id="heading-2">
                                                <h6 class="mb-0">
                                                <a data-toggle="collapse" href="#collapse-2" aria-expanded="false" aria-controls="collapse-2" class="collapsed">
                                                    <span class="h3 text-primary">Lorem Ipsus</span>
                                                    <span class="webinar-autor">Por Lorem Ipsus</span>
                                                    
                                                </a>
                                                </h6>
                                            </div>
                                            <div id="collapse-2" class="collapse" role="tabpanel" aria-labelledby="heading-2" data-parent="#accordion-2" style="">
                                            <div class="card-body">
                                            <div class="row">
                                                <div class="col-3">
                                                <img src="images/webinar.jpg" class="mw-100" alt="image">                              
                                                </div>
                                                <div class="col-9">
                                                <p class="mb-0 color-white">You can pay for the product you have purchased using credit cards, debit cards, or via online banking. 
                                                We also on-delivery services.</p>                             
                                                </div>
                                            </div>
                                            </div>
                                        </div>
                                        </div>

                                        <div class="card webinar-shadow">
                                            <div class="card-header" role="tab" id="heading-10">
                                                <h6 class="mb-0">
                                                <a data-toggle="collapse" href="#collapse-10" aria-expanded="false" aria-controls="collapse-10" class="collapsed">
                                                    <span class="h3 text-primary">Lorem Ipsus</span>
                                                    <span class="webinar-autor">Por Lorem Ipsus</span>
                                                    
                                                </a>
                                                </h6>
                                            </div>
                                            <div id="collapse-10" class="collapse" role="tabpanel" aria-labelledby="heading-10" data-parent="#accordion-4" style="">
                                            <div class="card-body">
                                            <div class="row">
                                                <div class="col-3">
                                                <img src="images/webinar.jpg" class="mw-100" alt="image">                              
                                                </div>
                                                <div class="col-9">
                                                <p class="mb-0 color-white">You can pay for the product you have purchased using credit cards, debit cards, or via online banking. 
                                                We also on-delivery services.</p>                             
                                                </div>
                                            </div>
                                            </div>
                                        </div>
                                        </div>

                                    </div>

                                </div>

                            </div>

                        </div>

                    </div>

                    

                </div>

            </div>

         
        </div>
        <!-- content-wrapper ends -->
        <!-- partial:partials/_footer.html -->
        <footer class="footer">
        <div class="container">
            <div class="w-100 clearfix">
                <span class="d-block text-center text-sm-left d-sm-inline-block">Copyright © 2018 <a href="http://www.urbanui.com/" target="_blank">Urbanui</a>. All rights reserved.</span>
                <span class="float-none float-sm-right d-block mt-1 mt-sm-0 text-center">Hand-crafted & made with <i class="mdi mdi-heart-outline text-danger"></i></span>
              </div>
        </div>
      </footer>
        <!-- partial -->
      </div>
      <!-- main-panel ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>
  <!-- container-scroller -->

  <!-- base:js -->
  <script src="vendors/js/vendor.bundle.base.js"></script>
  <!-- endinject -->
  <!-- End plugin js for this page-->
  <!-- inject:js -->
  <script src="Scripts/js/off-canvas.js"></script>
  <script src="Scripts/js/hoverable-collapse.js"></script>
  <script src="Scripts/js/template.js"></script>
  <script src="Scripts/js/settings.js"></script>
  <script src="Scripts/js/todolist.js"></script>
  <!-- endinject -->
  <!-- plugin js for this page -->
  <script src="https://kit.fontawesome.com/81717efc38.js" crossorigin="anonymous"></script>
  <!-- End plugin js for this page -->
  <!-- Custom js for this page-->
  <!--<script src="Scripts/js/dashboard.js"></script>-->
  <script src="Scripts/js/todolist.js"></script>
  <!-- End custom js for this page-->
</body>

</html>
