<?xml version="1.0" encoding="utf-8"?>
<Entity xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Uid>f1254386-a72a-4f41-9986-8060c7dae23a</Uid>
  <Name>ContractorExt</Name>
  <DisplayName>ContractorExt</DisplayName>
  <Namespace>Yambr.ELMA.Email.Models</Namespace>
  <BaseClassUid>38096146-0c73-4809-94f5-e18b2d525531</BaseClassUid>
  <Properties>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>f296ac2f-83c2-45e6-8357-4e0f36b42043</Uid>
      <Name>Domains</Name>
      <DisplayName>Домены</DisplayName>
      <Description>письма с этих доменов автоматически создадут новые контакты и прикрепят к ним новые письма</Description>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>9634d99b-edd4-45fe-9b2e-0dc68465bcc0</SubTypeUid>
      <Settings xsi:type="EntitySettings">
        <RelationType>OneToMany</RelationType>
        <KeyColumnUid>58c867aa-df79-4795-b3a4-8be6fb9b740c</KeyColumnUid>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>0</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
  </Properties>
  <FormsScheme>FormConstructor</FormsScheme>
  <FormTransformations>
    <FormViewItemTransformation>
      <Uid>43452920-ec84-4f11-b3c2-4efaeb99540c</Uid>
      <FormName>Display</FormName>
      <Items>
        <ViewItemTransformation xsi:type="ViewItemTransformationMove">
          <Uid>bf6e8266-403d-4559-b136-a62e3256fa4d</Uid>
          <MoveItemUid>92d255c1-3006-43be-81d3-e174a9366987</MoveItemUid>
          <BeforeItem>932bee4f-e8ad-4517-ab18-b51875b8ba23</BeforeItem>
          <AfterItem>4d8e2d2d-854f-434d-8b1f-d4229cc475f1</AfterItem>
        </ViewItemTransformation>
        <ViewItemTransformation xsi:type="ViewItemTransformationMove">
          <Uid>bf6e8266-403d-4559-b136-a62e3256fa4d</Uid>
          <MoveItemUid>932bee4f-e8ad-4517-ab18-b51875b8ba23</MoveItemUid>
          <BeforeItem>a45a3146-d52b-450a-b193-a324e09e554e</BeforeItem>
          <AfterItem>92d255c1-3006-43be-81d3-e174a9366987</AfterItem>
        </ViewItemTransformation>
        <ViewItemTransformation xsi:type="ViewItemTransformationMove">
          <Uid>bf6e8266-403d-4559-b136-a62e3256fa4d</Uid>
          <MoveItemUid>a45a3146-d52b-450a-b193-a324e09e554e</MoveItemUid>
          <BeforeItem>38a82144-c5c1-4bf9-b944-aa7069126427</BeforeItem>
          <AfterItem>932bee4f-e8ad-4517-ab18-b51875b8ba23</AfterItem>
        </ViewItemTransformation>
        <ViewItemTransformation xsi:type="ViewItemTransformationMove">
          <Uid>bf6e8266-403d-4559-b136-a62e3256fa4d</Uid>
          <MoveItemUid>38a82144-c5c1-4bf9-b944-aa7069126427</MoveItemUid>
          <BeforeItem>8c7dc804-ee44-4dfc-baec-0232609b99c7</BeforeItem>
          <AfterItem>a45a3146-d52b-450a-b193-a324e09e554e</AfterItem>
        </ViewItemTransformation>
        <ViewItemTransformation xsi:type="ViewItemTransformationMove">
          <Uid>bf6e8266-403d-4559-b136-a62e3256fa4d</Uid>
          <MoveItemUid>8c7dc804-ee44-4dfc-baec-0232609b99c7</MoveItemUid>
          <AfterItem>38a82144-c5c1-4bf9-b944-aa7069126427</AfterItem>
        </ViewItemTransformation>
        <ViewItemTransformation xsi:type="ViewItemTransformationAdd">
          <Uid>bf6e8266-403d-4559-b136-a62e3256fa4d</Uid>
          <Item xsi:type="TabViewItem">
            <Name>EmailMesagesTab</Name>
            <Uid>80b8d21b-7a84-43b2-98e1-5807aadbf085</Uid>
            <Caption>История переписки</Caption>
          </Item>
          <BeforeItem>92d255c1-3006-43be-81d3-e174a9366987</BeforeItem>
          <AfterItem>4d8e2d2d-854f-434d-8b1f-d4229cc475f1</AfterItem>
        </ViewItemTransformation>
        <ViewItemTransformation xsi:type="ViewItemTransformationAdd">
          <Uid>80b8d21b-7a84-43b2-98e1-5807aadbf085</Uid>
          <Item xsi:type="ExtensionZoneViewItem">
            <Name>ExtensionZone2</Name>
            <Uid>8ac59bf8-40b8-406d-a7fb-f6c55dbebaa5</Uid>
            <ZoneId>Contractor.EmailMessages</ZoneId>
          </Item>
        </ViewItemTransformation>
      </Items>
    </FormViewItemTransformation>
  </FormTransformations>
  <TableViews>
    <TableView>
      <Uid>e7c98776-cd21-43f9-9290-b27741b61630</Uid>
      <ViewType>List</ViewType>
    </TableView>
  </TableViews>
  <Type>InterfaceExtension</Type>
  <ImplementationUid>88daecfa-09ba-4e4c-85ba-97878639bbc0</ImplementationUid>
  <IdTypeUid>d90a59af-7e47-48c5-8c4c-dad04834e6e3</IdTypeUid>
  <TableName>ContractorExt</TableName>
  <IsSoftDeletable>true</IsSoftDeletable>
  <Actions />
</Entity>