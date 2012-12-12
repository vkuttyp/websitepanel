<?php if (!defined('WHMCS')) exit('ACCESS DENIED');
/**
 * WebsitePanel Addons Addon Module
 * 
 * @author Christopher York
 * @package WebsitePanel Addons Addon Module
 * @version v1.0
 * @link http://www.websitepanel.net/
 */

/**
 * websitepanel_addons_config
 * 
 * @access public
 * @return array
 */
function websitepanel_addons_config()
{
    $configarray = array('name' => 'WebsitePanel Addons Automation',
                         'description' => 'Automates WHMCS product addons with WebsitePanel',
                         'version' => '1.0',
                         'author' => 'Christopher York',
                         'fields' => array('serverhost' => array('FriendlyName', 'Enterprise Server Host', 'Type' => 'text', 'Size' => 25, 'Description' => 'Enterprise Server hostname / IP address', 'Default' => '127.0.0.1'),
                                           'serverport' => array('FriendlyName', 'Enterprise Server Port', 'Type' => 'text', 'Size' => 4, 'Description' => 'Enterprise Server port', 'Default' => 9002),
                                           'serversecured' => array('FriendlyName', 'Use Secured Connection', 'Type' => 'yesno', 'Description' => 'Tick to use SSL secured connection'),
                                           'username' => array('FriendlyName', 'Username', 'Type' => 'text', 'Size' => 25, 'Description' => 'Enterprise Server username', 'Default' => 'serveradmin'),
                                           'password' => array('FriendlyName', 'Password', 'Type' => 'password', 'Size' => 25, 'Description' => 'Enterprise Server password')
                                           )
                        );
    return $configarray;
}

/**
 * websitepanel_addons_activate
 *
 * @access public
 * @return array
 */
function websitepanel_addons_activate()
{
    // Create the WebsitePanel Addons table
    $query = "CREATE TABLE `tblwspaddons` (
              `whmcs_id` int(11) NOT NULL,
              `wsp_id` int(11) NOT NULL,
              `is_ipaddress` bit(1) NOT NULL DEFAULT b'0',
              PRIMARY KEY (`whmcs_id`)
              ) ENGINE=InnoDB DEFAULT CHARSET=utf8;";
    $result = full_query($query);
    
    // Check the results to verify that the table has been created properly
    if (!$result)
    {
        return array('status' => 'error', 'description' => 'There was an error while activating the module');
    }
    else
    {
        return array('status' => 'success', 'description' => 'The module has been activated successfully');
    }
}

/**
 * websitepanel_addons_deactivate
 *
 * @access public
 * @return array
 */
function websitepanel_addons_deactivate()
{
    // Create the WebsitePanel Addons table
    $query = 'DROP TABLE `tblwspaddons`';
    $result = full_query($query);

    // Check the results to verify that the table has been created properly
    if (!$result)
    {
        return array('status' => 'error', 'description' => 'There was an error while deactiviting the module');
    }
    else
    {
        return array('status' => 'success', 'description' => 'The module has been deactivated successfully');
    }
}

/**
 * websitepanel_addons_output
 *
 * @access public
 * @return mixed
 */
function websitepanel_addons_output($params)
{
    // Delete the requested WebsitePanel addon
    if (isset($_GET['action']) && $_GET['action'] == 'delete')
    {
        delete_query('tblwspaddons', array('whmcs_id' => $_GET['id']));
    }
    
    // Add the requested WebsitePanel addon
    if ($_POST && isset($_POST['action']) && $_POST['action'] == 'add')
    {
        // Sanity check to make sure the WHMCS addon ID exists
        $results = select_query('tbladdons', 'id', array('id' => $_POST['whmcs_id']));
        if (mysql_num_rows($results) > 0)
        {
            $results = select_query('tblwspaddons', 'whmcs_id', array('whmcs_id' => $_POST['whmcs_id']));
            if (mysql_num_rows($results) > 0)
            {
                echo '<p><div style="margin:0 0 -5px 0;padding: 10px;background-color: #FBEEEB;border: 1px dashed #cc0000;font-weight: bold;color: #cc0000;font-size:14px;text-align: center;-moz-border-radius: 10px;-webkit-border-radius: 10px;-o-border-radius: 10px;border-radius: 10px;">Duplicate WHMCS Addon ID. The WHMCS Addon ID Is Assigned To Another WebsitePanel Addon.</div></p>';
            }
            else
            {
                insert_query('tblwspaddons', array('whmcs_id' => $_POST['whmcs_id'], 'wsp_id' => $_POST['wsp_id'], 'is_ipaddress' => $_POST['is_ipaddress']));
            }
        }
        else
        {
            echo '<p><div style="margin:0 0 -5px 0;padding: 10px;background-color: #FBEEEB;border: 1px dashed #cc0000;font-weight: bold;color: #cc0000;font-size:14px;text-align: center;-moz-border-radius: 10px;-webkit-border-radius: 10px;-o-border-radius: 10px;border-radius: 10px;">WHMCS Addon Not Found! Check The ID And Try Again.</div></p>';
        }
    }
    
    // Get all the assigned addons and display them to the user
    $results = full_query('SELECT a.name AS `name`, a.id AS `whmcs_id`, w.wsp_id AS `wsp_id` FROM `tbladdons` AS a, `tblwspaddons` AS w WHERE w.whmcs_id = a.id');
    
    // Build the table / data grid
    echo '<div class="tablebg">';
    echo '<table class="datatable" width="100%" border="0" cellspacing="1" cellpadding="3">';
    echo '<tr><th>Addon Name</th><th>WHMCS ID</th><th>WebsitePanel ID</th><th></th></tr>';
    if (mysql_num_rows($results) > 0)
    {
        while (($row = mysql_fetch_array($results)) != false)
        {
            echo "<tr><td>{$row['name']}</td><td>{$row['whmcs_id']}</td><td>{$row['wsp_id']}</td><td><a href=\"{$params['modulelink']}&action=delete&id={$row['whmcs_id']}\" onclick=\"return confirm('Are you sure you want to delete this addon?');\">Delete</td></td></tr>";
        }
    }
    else
    {
        echo '<tr><td colspan="4">No Addon Data Found</td></tr>';
    }
    echo '</table></div>';
    
    // Build the add addon form
    echo '<p><strong>Add WebsitePanel Addon</strong></p>';
    echo "<form action=\"{$params['modulelink']}\" method=\"POST\">";
    echo '<input type="hidden" name="action" id="action" value="add">';
    echo '<table class="form" "width="100%" border="0" cellspacing="2" cellpadding="3">';
    echo '<tr><td class="fieldlabel">WHMCS Addon ID</td><td class="fieldarea"><input type="text" name="whmcs_id" id="whmcs_id"></td></tr>';
    echo '<tr><td class="fieldlabel">WebsitePanel Addon ID</td><td class="fieldarea"><input type="text" name="wsp_id" id="wsp_id"></td></tr>';
    echo '<tr><td class="fieldlabel">Dedicated IP Addon</td><td class="fieldarea"><input type="checkbox" name="is_ipaddress" id="is_ipaddress" value="1"></td></tr>';
    echo '<tr><td colspan="2" class="fieldarea"><input type="submit" name="submit" id="submit" value="Submit"></td></tr>';
    echo '</form></table>';
}