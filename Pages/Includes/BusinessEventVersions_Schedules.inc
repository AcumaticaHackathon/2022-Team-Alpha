<px:PXTabItem Text="Schedules">
<Template>
    <px:PXFormView Width="500" DataMember="BusinessEventSchedules" Caption="Schedules" CaptionVisible="False" runat="server" ID="frmBusinessEventSchedules">
        <Template>
            <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdBusinessEventSchedules">
                <Levels>
                    <px:PXGridLevel DataMember="BusinessEventSchedules">
                        <Columns>
                            <px:PXGridColumn DataField="ScheduleID" Width="70"></px:PXGridColumn>
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
                    <CustomItems>
                        <px:PXToolBarButton Text="Schedule History"></px:PXToolBarButton>
                    </CustomItems>
                </ActionBar>
                <AutoSize MinHeight="200" MinWidth="200" Container="Parent"></AutoSize>
                <AutoSize MinHeight="200"></AutoSize>
                <AutoSize MinWidth="200"></AutoSize>
            </px:PXGrid>
        </Template>
    </px:PXFormView>
</Template>
</px:PXTabItem>