<px:PXTabItem Text="Trigger Conditions">
                                <Template>
                                    <px:PXFormView Width="500" DataMember="BusinessEventTriggerConditions" Caption="Trigger Conditions" CaptionVisible="False" runat="server" ID="frmBusinessEventTriggerConditions">
                                        <Template>
                                            <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdBusinessEventTriggerConditions">
                                                <Levels>
                                                    <px:PXGridLevel DataMember="BusinessEventTriggerConditions">
                                                        <Columns>
                                                            <px:PXGridColumn DataField="OrderNbr" Width="70"></px:PXGridColumn>
                                                            <px:PXGridColumn DataField="TableName" Width="280"></px:PXGridColumn>
                                                            <px:PXGridColumn DataField="FieldName" Width="280"></px:PXGridColumn>
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
                                                        <px:PXToolBarButton Text="Trig Cond History"></px:PXToolBarButton>
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