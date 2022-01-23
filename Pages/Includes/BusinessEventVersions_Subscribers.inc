<px:PXTabItem Text="Subscribers">
                                <Template>
                                    <px:PXFormView Width="500" Caption="Subscribers" CaptionVisible="False" DataMember="BusinessEventSubscribers" runat="server" ID="frmBusinessEventSubscribers">
                                        <Template>
                                            <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdBusinessEventSubscribers">
                                                <Levels>
                                                    <px:PXGridLevel DataMember="BusinessEventSubscribers">
                                                        <Columns>
                                                            <px:PXGridColumn DataField="OrderNbr" Width="70"></px:PXGridColumn>
                                                            <px:PXGridColumn DataField="HandlerID" Width="70"></px:PXGridColumn>
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
                                                        <px:PXToolBarButton Text="Subscriber History"></px:PXToolBarButton>
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