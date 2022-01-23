<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AK401010.aspx.cs" Inherits="Page_AK401010" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="Aktion.Common.Acumatica.NoCodeChangeTracking.Graphs.NoCodeChangeTrack"
        PrimaryView="Attributes">
        <CallbackCommands>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXTab Height="" DataMember="Attributes" runat="server" ID="tabObjectTypes">
        <Items>
            <px:PXTabItem Text="Attributes">
                <Template>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule26" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="500" CaptionVisible="False" Caption="Attributes" Height="" DataMember="Attributes" runat="server" ID="frmAttributes">
                        <Template>
                            <px:PXGrid SyncPosition="True" FilesIndicator="False" NoteIndicator="False" SkinID="" Height="300" runat="server" ID="grdAttributes">
                                <Levels>
                                    <px:PXGridLevel DataMember="Attributes">
                                        <Columns>
                                            <px:PXGridColumn DataField="AttributeID" Width="120"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="Description" Width="220"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="ControlType" Width="70"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="CreatedDateTime" Width="90"></px:PXGridColumn>
                                        </Columns>
                                    </px:PXGridLevel>
                                </Levels>
                                <ActionBar ActionsVisible="True">
                                    <Actions>
                                        <ExportExcel Enabled="True"></ExportExcel>
                                    </Actions>
                                </ActionBar>
                                <Mode AllowAddNew="False"></Mode>
                                <Mode AllowDelete="False"></Mode>
                                <Mode AllowUpdate="False"></Mode>
                                <AutoSize Container="Parent"></AutoSize>
                                <AutoSize MinHeight="200"></AutoSize>
                                <AutoSize MinWidth="200"></AutoSize>
                                <AutoCallBack Target="tabAttributeDetails" ActiveBehavior="True" Command="Refresh">
                                    <Behavior RepaintControlsIDs=""></Behavior>
                                </AutoCallBack>
                                <AutoCallBack Target="grdObjectVersions"></AutoCallBack>
                                <CallbackCommands>
                                    <Refresh RepaintControlsIDs="grdAttributeHistory,txtAttributeVersion,grdAttributeGroups,grdAttributeDetails"></Refresh>
                                </CallbackCommands>
                            </px:PXGrid>
                        </Template>
                        <AutoSize Container="Parent"></AutoSize>
                        <AutoSize MinHeight="200"></AutoSize>
                        <AutoSize MinWidth="200"></AutoSize>
                    </px:PXFormView>
                    <px:PXTab Width="500" DataMember="AttributeVersions" Height="" runat="server" ID="tabAttributeDetails">
                        <Items>
                            <!--#include file="~\Pages\AK\Includes\AttributeVersions_History.inc"-->
                            <!--#include file="~\Pages\AK\Includes\AttributeVersions_Options.inc"-->
                            <!--#include file="~\Pages\AK\Includes\AttributeVersions_Groups.inc"-->
                            <!--#include file="~\Pages\AK\Includes\AttributeVersions_Screens.inc"-->
                        </Items>
                    </px:PXTab>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule27" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="700" DataMember="AttributeCurrentVersion" Caption="Object Versions" runat="server" ID="frmCurrentAttributeVersion">
                        <Template>
                            <px:PXTextEdit Enabled="True" Height="700" Width="600" SuppressLabel="True" TextMode="MultiLine" runat="server" ID="txtAttributeVersion" DataField="ChangeObject"></px:PXTextEdit>
                        </Template>
                        <CallbackCommands>
                            <Refresh SelectControlsIDs="txtAttributeVersion" RepaintControlsIDs="txtAttributeVersion"></Refresh>
                        </CallbackCommands>
                    </px:PXFormView>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Biz Events">
                <Template>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule89" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="500" DataMember="BusinessEvents" runat="server" ID="frmBusEvents" Caption="Biz Events" CaptionVisible="False">
                        <Template>
                            <px:PXGrid SyncPosition="True" FilesIndicator="False" NoteIndicator="False" Height="300" runat="server" ID="grdBusEvents">
                                <Levels>
                                    <px:PXGridLevel DataMember="BusinessEvents">
                                        <Columns>
                                            <px:PXGridColumn DataField="EventID" Width="70"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="Name" Width="220"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="ActionName" Width="220"></px:PXGridColumn>
                                        </Columns>
                                    </px:PXGridLevel>
                                </Levels>
                                <AutoCallBack Command="Refresh" Target="tabBusEventDetails" ActiveBehavior="True">
                                    <Behavior RepaintControlsIDs="grdBusEventVersions,txtBusEventVersion,grdBusinessEventSubscribers,grdBusinessEventTriggerConditions,grdBusinessEventSchedules,grdBusinessEventInquiryParameters"></Behavior>
                                </AutoCallBack>
                                <AutoCallBack Command="Refresh"></AutoCallBack>
                                <AutoSize MinHeight="200" MinWidth="200" Container="Parent"></AutoSize>
                                <ActionBar ActionsVisible="True">
                                    <Actions>
                                        <AddNew Enabled="False"></AddNew>
                                        <Delete Enabled="False"></Delete>
                                        <EditRecord Enabled="False"></EditRecord>
                                        <Save Enabled="False"></Save>
                                    </Actions>
                                </ActionBar>
                            </px:PXGrid>
                        </Template>
                    </px:PXFormView>
                    <px:PXTab Width="500" DataMember="BusinessEventVersions" runat="server" ID="tabBusEventDetails">
                        <Items>
                            <!--#include file="~\Pages\AK\Includes\BusinessEventVersions_History.inc"-->
                            <!--#include file="~\Pages\AK\Includes\BusinessEventVersions_Subscribers.inc"-->
                            <!--#include file="~\Pages\AK\Includes\BusinessEventVersions_TriggerConditions.inc"-->
                            <!--#include file="~\Pages\AK\Includes\BusinessEventVersions_Schedules.inc"-->
                            <!--#include file="~\Pages\AK\Includes\BusinessEventVersions_InquiryParameters.inc"-->
                        </Items>
                    </px:PXTab>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule90" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="700" Caption="Object Versions" DataMember="BusinessEventVersions" runat="server" ID="frmBusEventCurrentVersion">
                        <Template>
                            <px:PXTextEdit SuppressLabel="True" TextMode="MultiLine" Width="700" Enabled="True" Height="700" runat="server" ID="txtBusEventVersion" DataField="ChangeObject"></px:PXTextEdit>
                        </Template>
                    </px:PXFormView>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Dashboards">
                <Template>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule56" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="500" Caption="Dashboards" CaptionVisible="False" DataMember="Dashboards" runat="server" ID="frmDashboards">
                        <Template>
                            <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdDashboards">
                                <Levels>
                                    <px:PXGridLevel DataMember="Dashboards">
                                        <Columns>
                                            <px:PXGridColumn DataField="Name" Width="280"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="ScreenID" Width="96"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="DashboardID" Width="70"></px:PXGridColumn>
                                        </Columns>
                                    </px:PXGridLevel>
                                </Levels>
                                <ActionBar ActionsVisible="True">
                                    <Actions>
                                        <AddNew Enabled="False"></AddNew>
                                        <ExportExcel Enabled="True"></ExportExcel>
                                        <Delete Enabled="False"></Delete>
                                        <Save Enabled="False"></Save>
                                    </Actions>
                                </ActionBar>
                                <ActionBar>
                                    <Actions>
                                        <Delete Enabled="False"></Delete>
                                    </Actions>
                                </ActionBar>
                                <AutoCallBack Command="Refresh" Target="tabDashboardDetails" ActiveBehavior="True">
                                    <Behavior RepaintControlsIDs="grdDashboardHistory,txtDashboardVersion,grdWidgets,grdDashboardParameters,grdWebHooks"></Behavior>
                                </AutoCallBack>
                                <AutoCallBack Command="Refresh"></AutoCallBack>
                                <AutoSize MinHeight="200" MinWidth="200" Container="Parent"></AutoSize>
                                <Mode AllowAddNew="False"></Mode>
                                <CallbackCommands>
                                    <Refresh RepaintControlsIDs="grdDashboardHistory,txtDashboardVersion,grdWidgets"></Refresh>
                                </CallbackCommands>
                            </px:PXGrid>
                        </Template>
                    </px:PXFormView>
                    <px:PXTab Width="500" DataMember="DashboardVersions" runat="server" ID="tabDashboardDetails">
                        <Items>
                            <!--#include file="~\Pages\AK\Includes\DashboardVersions_History.inc"-->
                            <!--#include file="~\Pages\AK\Includes\DashboardVersions_Widgets.inc"-->
                            <!--#include file="~\Pages\AK\Includes\DashboardVersions_Parameters.inc"-->
                        </Items>
                    </px:PXTab>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule57" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="700" Caption="Object Versions" DataMember="DashboardVersions" runat="server" ID="frmDashboardCurrentVersion">
                        <Template>
                            <px:PXTextEdit TextMode="MultiLine" Width="700" Enabled="True" Height="700" SuppressLabel="True" runat="server" ID="txtDashboardVersion" DataField="ChangeObject"></px:PXTextEdit>
                        </Template>
                    </px:PXFormView>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="GIs">
                <Template>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule137" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="500" DataMember="GIs" Caption="GIs" CaptionVisible="False" runat="server" ID="frmGIs">
                        <Template>
                            <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" runat="server" ID="grdGIs" Height="300">
                                <Levels>
                                    <px:PXGridLevel DataMember="GIs">
                                        <Columns>
                                            <px:PXGridColumn DataField="Name" Width="280"></px:PXGridColumn>
                                        </Columns>
                                    </px:PXGridLevel>
                                </Levels>
                                <ActionBar ActionsVisible="True">
                                    <Actions>
                                        <AddNew Enabled="False"></AddNew>
                                        <Delete Enabled="False"></Delete>
                                        <EditRecord Enabled="False"></EditRecord>
                                        <Save Enabled="False"></Save>
                                    </Actions>
                                </ActionBar>
                                <AutoCallBack ActiveBehavior="True" Target="tabGIDetails" Command="Refresh">
                                    <Behavior RepaintControlsIDs="grdGIHistory,grdGIFilters,grdGIGroupBys,grdGIOns,grdGIRelations,grdGIResults,grdGISorts,grdGITables,grdGIWheres,txtGIVersion"></Behavior>
                                </AutoCallBack>
                                <AutoSize MinHeight="200" MinWidth="200" Container="Parent"></AutoSize>
                            </px:PXGrid>
                        </Template>
                    </px:PXFormView>
                    <px:PXTab Width="500" DataMember="GIVersions" runat="server" ID="tabGIDetails">
                        <Items>
                            <!--#include file="~\Pages\AK\Includes\GIVersions_History.inc"-->
                            <!--#include file="~\Pages\AK\Includes\GIVersions_Filters.inc"-->
                            <!--#include file="~\Pages\AK\Includes\GIVersions_GroupBys.inc"-->
                            <!--#include file="~\Pages\AK\Includes\GIVersions_Ons.inc"-->
                            <!--#include file="~\Pages\AK\Includes\GIVersions_Relations.inc"-->
                            <!--#include file="~\Pages\AK\Includes\GIVersions_Results.inc"-->
                            <!--#include file="~\Pages\AK\Includes\GIVersions_Sorts.inc"-->
                            <!--#include file="~\Pages\AK\Includes\GIVersions_Tables.inc"-->
                            <!--#include file="~\Pages\AK\Includes\GIVersions_Wheres.inc"-->
                        </Items>
                    </px:PXTab>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule138" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="700" DataMember="GIVersions" Caption="Object Versions" runat="server" ID="frmGICurrentVersion">
                        <Template>
                            <px:PXTextEdit SuppressLabel="True" TextMode="MultiLine" Width="700" Enabled="True" Height="700" runat="server" ID="txtGIVersion" DataField="ChangeObject"></px:PXTextEdit>
                        </Template>
                    </px:PXFormView>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Reports">
                <Template>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule30" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="500" Caption="Reports" CaptionVisible="False" DataMember="Reports" runat="server" ID="frmReports">
                        <Template>
                            <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdReports">
                                <Levels>
                                    <px:PXGridLevel DataMember="Reports">
                                        <Columns>
                                            <px:PXGridColumn DataField="ReportFileName" Width="180"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="Version" Width="70"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="Description" Width="180"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="CreatedDateTime" Width="90"></px:PXGridColumn>
                                        </Columns>
                                    </px:PXGridLevel>
                                </Levels>
                                <AutoSize Container="Parent"></AutoSize>
                                <AutoCallBack Command="Refresh" Target="tabReportDetails" ActiveBehavior="True">
                                    <Behavior RepaintControlsIDs="frmCurrentAttributeVersion"></Behavior>
                                </AutoCallBack>
                                <AutoCallBack Command="Refresh"></AutoCallBack>
                                <CallbackCommands>
                                    <Refresh RepaintControlsIDs="grdReportHistory,txtReportVersion"></Refresh>
                                </CallbackCommands>
                                <ActionBar ActionsVisible="True">
                                    <Actions>
                                        <AddNew Enabled="False"></AddNew>
                                        <Delete Enabled="False"></Delete>
                                        <EditRecord Enabled="False"></EditRecord>
                                        <Save Enabled="False"></Save>
                                    </Actions>
                                </ActionBar>
                                <ActionBar>
                                    <Actions>
                                        <Delete Enabled="False"></Delete>
                                    </Actions>
                                </ActionBar>
                            </px:PXGrid>
                        </Template>
                    </px:PXFormView>
                    <px:PXTab Width="500" FilesIndicator="True" NoteIndicator="True" SyncPosition="False" DataMember="ReportVersions" runat="server" ID="tabReportDetails">
                        <Items>
                            <!--#include file="~\Pages\AK\Includes\ReportVersions_History.inc"-->
                        </Items>
                    </px:PXTab>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule38" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="500" DataMember="ReportVersions" runat="server" ID="frmCurrentReportVersion">
                        <Template>
                            <px:PXTextEdit Width="700" Enabled="True" Height="700" SuppressLabel="True" TextMode="MultiLine" runat="server" ID="txtReportVersion" DataField="ChangeObject"></px:PXTextEdit>
                        </Template>
                    </px:PXFormView>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Roles">
                <Template>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule107" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="500" DataMember="Roles" Caption="Roles" CaptionVisible="False" runat="server" ID="frmRoles">
                        <Template>
                            <px:PXGrid SyncPosition="True" FilesIndicator="False" NoteIndicator="False" runat="server" ID="grdRoles" Height="300">
                                <Levels>
                                    <px:PXGridLevel DataMember="Roles">
                                        <Columns>
                                            <px:PXGridColumn DataField="Rolename" Width="220"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="ApplicationName" Width="180"></px:PXGridColumn>
                                        </Columns>
                                    </px:PXGridLevel>
                                </Levels>
                                <AutoSize MinHeight="200" MinWidth="200" Container="Parent"></AutoSize>
                                <ActionBar ActionsVisible="True">
                                    <Actions>
                                        <AddNew Enabled="False"></AddNew>
                                        <EditRecord Enabled="False"></EditRecord>
                                        <Save Enabled="False"></Save>
                                        <Delete Enabled="False"></Delete>
                                    </Actions>
                                </ActionBar>
                                <AutoCallBack Target="tabRoleDetails" Command="Refresh" ActiveBehavior="True">
                                    <Behavior RepaintControlsIDs="grdRoleVersions,grdRolesInCaches,grdRolesInGraphs,grdRolesInMembers,txtRoleVersion"></Behavior>
                                </AutoCallBack>
                                <AutoCallBack Command="Refresh"></AutoCallBack>
                            </px:PXGrid>
                        </Template>
                    </px:PXFormView>
                    <px:PXTab Width="500" runat="server" ID="tabRoleDetails" DataMember="RoleVersions">
                        <Items>
                            <!--#include file="~\Pages\AK\Includes\RoleVersions_History.inc"-->
                            <!--#include file="~\Pages\AK\Includes\RoleVersions_Caches.inc"-->
                            <!--#include file="~\Pages\AK\Includes\RoleVersions_Graphs.inc"-->
                            <!--#include file="~\Pages\AK\Includes\RoleVersions_Members.inc"-->
                        </Items>
                    </px:PXTab>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule108" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Height="700" Caption="Object Versions" DataMember="RoleVersions" runat="server" ID="frmRoleCurrentVersion">
                        <Template>
                            <px:PXTextEdit Width="700" SuppressLabel="True" TextMode="MultiLine" Enabled="True" Height="700" runat="server" ID="txtRoleVersion" DataField="ChangeObject"></px:PXTextEdit>
                        </Template>
                    </px:PXFormView>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Scenarios">
                <Template>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule122" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView DataMember="ScenarioMappings" Caption="Scenarios" CaptionVisible="False" runat="server" ID="frmScenarioMappings">
                        <Template>
                            <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdScenarioMappings">
                                <Levels>
                                    <px:PXGridLevel DataMember="ScenarioMappings">
                                        <Columns>
                                            <px:PXGridColumn DataField="Name" Width="250"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="ScreenID" Width="96"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="GraphName" Width="250"></px:PXGridColumn>
                                        </Columns>
                                    </px:PXGridLevel>
                                </Levels>
                                <ActionBar ActionsVisible="True">
                                    <Actions>
                                        <AddNew Enabled="False"></AddNew>
                                        <Delete Enabled="False"></Delete>
                                        <EditRecord Enabled="False"></EditRecord>
                                        <Save Enabled="False"></Save>
                                    </Actions>
                                </ActionBar>
                                <AutoSize MinHeight="200" MinWidth="200" Container="Parent"></AutoSize>
                                <AutoCallBack Command="Refresh" Target="tabScenarioMappingDetails" ActiveBehavior="True">
                                    <Behavior RepaintControlsIDs="grdScenarioMappingVersions,grdScenarioMappingConditions,grdScenarioMappingFields,grdScenarioImportConditions,txtScenarioMappingVersion"></Behavior>
                                </AutoCallBack>
                                <AutoCallBack Command="Refresh"></AutoCallBack>
                            </px:PXGrid>
                        </Template>
                    </px:PXFormView>
                    <px:PXTab Width="500" DataMember="ScenarioMappingVersions" runat="server" ID="tabScenarioMappingDetails">
                        <Items>
                            <!--#include file="~\Pages\AK\Includes\ScenarioMappingVersions_History.inc"-->
                            <!--#include file="~\Pages\AK\Includes\ScenarioMappingVersions_MappingConditions.inc"-->
                            <!--#include file="~\Pages\AK\Includes\ScenarioMappingVersions_MappingFields.inc"-->
                            <!--#include file="~\Pages\AK\Includes\ScenarioMappingVersions_ImportConditions.inc"-->
                        </Items>
                    </px:PXTab>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule123" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Height="700" Caption="Object Versions" DataMember="ScenarioMappingVersions" runat="server" ID="frmScenarioMappingCurrentVersion">
                        <Template>
                            <px:PXTextEdit SuppressLabel="True" TextMode="MultiLine" Width="700" Enabled="True" Height="700" runat="server" ID="txtScenarioMappingVersion" DataField="ChangeObject"></px:PXTextEdit>
                        </Template>
                    </px:PXFormView>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Sitemaps">
                <Template>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule67" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="500" DataMember="Sitemaps" runat="server" ID="frmSitemaps" Caption="Sitemaps" CaptionVisible="False">
                        <Template>
                            <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdSitemaps">
                                <Levels>
                                    <px:PXGridLevel DataMember="Sitemaps">
                                        <Columns>
                                            <px:PXGridColumn DataField="Title" Width="280"></px:PXGridColumn>
                                            <px:PXGridColumn DataField="ScreenID" Width="96"></px:PXGridColumn>
                                        </Columns>
                                    </px:PXGridLevel>
                                </Levels>
                                <ActionBar ActionsVisible="True">
                                    <Actions>
                                        <AddNew Enabled="False"></AddNew>
                                        <Delete Enabled="False"></Delete>
                                        <Save Enabled="False"></Save>
                                        <ExportExcel Enabled="True"></ExportExcel>
                                    </Actions>
                                </ActionBar>
                                <AutoSize Container="Parent"></AutoSize>
                                <AutoSize MinHeight="200"></AutoSize>
                                <AutoSize MinWidth="200"></AutoSize>
                                <AutoCallBack Target="tabSitemapDetails" Command="Refresh" ActiveBehavior="True">
                                    <Behavior RepaintControlsIDs="grdSitemapHistory,txtSitemapVersion"></Behavior>
                                </AutoCallBack>
                                <AutoCallBack Command="Refresh"></AutoCallBack>
                            </px:PXGrid>
                        </Template>
                    </px:PXFormView>
                    <px:PXTab Width="500" runat="server" ID="tabSitemapDetails" DataMember="SitemapVersions">
                        <Items>
                            <!--#include file="~\Pages\AK\Includes\SitemapVersions_History.inc"-->
                        </Items>
                    </px:PXTab>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule68" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="700" Caption="Object Versions" DataMember="SitemapVersions" runat="server" ID="frmSitemapVersions">
                        <Template>
                            <px:PXTextEdit SuppressLabel="True" TextMode="MultiLine" Width="700" Enabled="True" Height="700" runat="server" ID="txtSitemapVersion" DataField="ChangeObject"></px:PXTextEdit>
                        </Template>
                    </px:PXFormView>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="WebHooks">
                <Template>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule80" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="500" DataMember="WebHooks" Caption="WebHooks" CaptionVisible="False" runat="server" ID="frmWebHooks">
                        <Template>
                            <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" runat="server" ID="grdWebHooks" Height="300">
                                <Levels>
                                    <px:PXGridLevel DataMember="WebHooks">
                                        <Columns>
                                            <px:PXGridColumn DataField="Name" Width="250"></px:PXGridColumn>
                                        </Columns>
                                    </px:PXGridLevel>
                                </Levels>
                                <ActionBar ActionsVisible="True">
                                    <Actions>
                                        <AddNew Enabled="False"></AddNew>
                                        <Delete Enabled="False"></Delete>
                                        <EditRecord Enabled="False"></EditRecord>
                                        <Save Enabled="False"></Save>
                                    </Actions>
                                </ActionBar>
                                <AutoSize Container="Parent"></AutoSize>
                                <AutoCallBack Target="tabWebHookDetails" Command="Refresh" ActiveBehavior="True"></AutoCallBack>
                                <AutoCallBack Command="Refresh"></AutoCallBack>
                                <AutoCallBack Target="tabWebHookDetails"></AutoCallBack>
                            </px:PXGrid>
                        </Template>
                    </px:PXFormView>
                    <px:PXTab Width="500" DataMember="WebHookVersions" runat="server" ID="tabWebHookDetails">
                        <Items>
                            <!--#include file="~\Pages\AK\Includes\WebHookVersions_History.inc"-->
                        </Items>
                    </px:PXTab>
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule81" StartColumn="True"></px:PXLayoutRule>
                    <px:PXFormView Width="700" DataMember="WebHookVersions" runat="server" ID="frmWebHookVersions" Caption="Object Versions">
                        <Template>
                            <px:PXTextEdit TextMode="MultiLine" Width="700" SuppressLabel="True" Enabled="True" Height="700" runat="server" ID="txtWebHookVersion" DataField="ChangeObject"></px:PXTextEdit>
                        </Template>
                    </px:PXFormView>
                </Template>
            </px:PXTabItem>
        </Items>
        <AutoSize Container="Parent"></AutoSize>
    </px:PXTab>
</asp:Content>

